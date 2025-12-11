
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

internal class TcpServer
{
    private readonly int port = 3636;
    private TcpListener listener;
    private bool running = false;
    
    private readonly string connectionString =
        ConfigurationManager.ConnectionStrings["QuizDB"]?.ConnectionString
        ?? @"Server=.;Database=QuizDB;Integrated Security=True;TrustServerCertificate=True;";

    private class RoomInfo
    {
        public int HostUserId { get; set; }
        public int QuizId { get; set; }

        public int CurrentQuestionIndex { get; set; } = -1;     
        public DateTime? QuestionStartTime { get; set; }
        public int QuestionDurationSeconds { get; set; } = 0;

        public int PlayerCount { get; set; } = 0;
    }

    private readonly Dictionary<string, RoomInfo> rooms
        = new Dictionary<string, RoomInfo>();
    private readonly object roomsLock = new object();

    public void Start()
    {
        Console.WriteLine("[DB] Using CS: " + connectionString);
        try
        {
            EnsureDb();

            using (var test = new SqlConnection(connectionString))
            {
                test.Open();
                using (var cmd = new SqlCommand("SELECT DB_ID('QuizDB')", test))
                {
                    var id = cmd.ExecuteScalar();
                    Console.WriteLine("[DB] DB_ID(QuizDB) = " + (id == null ? "NULL" : id.ToString()));
                }
            }
            Console.WriteLine("[SERVER] DB ready.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("[SERVER] EnsureDb/Test error: " + ex);
        }
        listener = new TcpListener(IPAddress.Any, port);
        listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        listener.Start();
        running = true;
        Console.WriteLine("[SERVER] Listening on port " + port + "...");
        while (running)
        {
            try
            {
                var client = listener.AcceptTcpClient();
                try
                {
                    var ep = (IPEndPoint)client.Client.RemoteEndPoint;
                    Console.WriteLine("[SERVER] Client connected: " + ep.Address + ":" + ep.Port);
                }
                catch { Console.WriteLine("[SERVER] Client connected!"); }

                var t = new Thread(() => HandleClient(client)) { IsBackground = true };
                t.Start();
            }
            catch (SocketException se)
            {
                if (!running) break;
                Console.WriteLine("[SERVER] Socket error: " + se.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("[SERVER] Accept error: " + e);
            }
        }

        Console.WriteLine("[SERVER] Stopped.");
    }
    private void HandleClient(TcpClient client)
    {
        using (client)
        using (NetworkStream stream = client.GetStream())
        {
            try
            {
                string rawJson = ReadLine(stream);
                Console.WriteLine("[SERVER] Received: " + rawJson);
                var data = JsonSerializer.Deserialize<Dictionary<string, object>>(rawJson);
                string response = ProcessRequest(rawJson, data);
                WriteLine(stream, response);
                Console.WriteLine("[SERVER] Sent: " + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[SERVER] Error: " + ex);
                WriteLine(stream, JsonSerializer.Serialize(new { ok = false, message = ex.Message }));
            }
        }
        Console.WriteLine("[SERVER] Client disconnected.");
    }
    private string ProcessRequest(string rawJson, Dictionary<string, object> data)
    {
        if (data == null)
            return JsonSerializer.Serialize(new { ok = false, message = "Lỗi JSON" });

        if (!data.TryGetValue("action", out var actionRaw))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu action" });

        string action = actionRaw?.ToString()?.Trim().ToLowerInvariant() ?? "";

        if (action == "register") return HandleRegister(data);
        if (action == "login") return HandleLogin(data);
        if (action == "profile") return HandleProfile(data);
        if (action == "get_my_quiz") return HandleGetMyQuiz(data);
        if (action == "delete_quiz") return HandleDeleteQuiz(data);
        if (action == "update_profile") return HandleUpdateProfile(data);
        if (action == "logout") return JsonSerializer.Serialize(new { ok = true, message = "Đăng xuất" });
        if (action == "update_avatar") return HandleUpdateAvatar(data);

        if (action == "create_exam") return HandleCreateExam(rawJson);

        if (action == "get_quiz_details") return HandleGetQuizDetails(data);
        if (action == "create_room") return HandleCreateRoom(data);
        if (action == "join_room") return HandleJoinRoom(data);
        if (action == "room_start_question") return HandleRoomStartQuestion(data);
        if (action == "room_get_state") return HandleRoomGetState(data);



        return JsonSerializer.Serialize(new { ok = false, message = "Action không hợp lệ" });
    }
    private string HandleUpdateAvatar(Dictionary<string, object> d)
    {
        string userId = d.TryGetValue("userId", out var u) ? u.ToString() : "";
        string avatar = d.TryGetValue("avatar", out var a) ? a?.ToString() : "";

        if (string.IsNullOrWhiteSpace(userId))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu userId" });

        try
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "UPDATE Users SET AvatarBase64=@A WHERE UserId=@ID", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", userId);
                cmd.Parameters.AddWithValue("@A",
                    string.IsNullOrWhiteSpace(avatar) ? (object)DBNull.Value : avatar);

                cmd.ExecuteNonQuery();
            }

            return JsonSerializer.Serialize(new { ok = true, message = "Avatar đã cập nhật" });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { ok = false, message = ex.Message });
        }
    }
    private string HandleRoomStartQuestion(Dictionary<string, object> d)
    {
        string roomId = d.TryGetValue("roomId", out var r) ? r?.ToString() : "";
        string idxStr = d.TryGetValue("questionIndex", out var qi) ? qi?.ToString() : "";
        string durStr = d.TryGetValue("durationSeconds", out var du) ? du?.ToString() : "";

        if (string.IsNullOrWhiteSpace(roomId) || string.IsNullOrWhiteSpace(idxStr))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu roomId/questionIndex" });

        if (!int.TryParse(idxStr, out int qIndex))
            return JsonSerializer.Serialize(new { ok = false, message = "questionIndex không hợp lệ" });

        int duration = 20; 
        if (!string.IsNullOrWhiteSpace(durStr))
            int.TryParse(durStr, out duration);

        lock (roomsLock)
        {
            if (!rooms.TryGetValue(roomId, out var info))
            {
                return JsonSerializer.Serialize(new { ok = false, message = "Phòng khônfg tồn tại" });
            }

            if (info.CurrentQuestionIndex >= info.QuizId) 
            {
                return JsonSerializer.Serialize(new { ok = false, message = "Đã hoàn thành tất cả các câu hỏi" });
            }

            info.CurrentQuestionIndex = qIndex;
            info.QuestionStartTime = DateTime.UtcNow;
            info.QuestionDurationSeconds = duration;

            Console.WriteLine($"[DEBUG] Room {roomId} - Started question {qIndex}, Duration {duration}s");

            return JsonSerializer.Serialize(new
            {
                ok = true,
                message = "Đã cập nhật câu hỏi",
                currentQuestionIndex = qIndex,
                durationSeconds = duration
            });
        }
    }


    private string HandleRegister(Dictionary<string, object> d)
    {
        string username = d.TryGetValue("username", out var u) ? u?.ToString() : "";
        string password = d.TryGetValue("password", out var pw) ? pw?.ToString() : "";
        string email = d.TryGetValue("email", out var e) ? e?.ToString() : "";
        string phone = d.TryGetValue("phone", out var p) ? p?.ToString() : "";

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return JsonSerializer.Serialize(new { ok = false, message = "Các ô không được để trống" });

        try
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Users WHERE Username=@u", conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    if ((int)cmd.ExecuteScalar() > 0)
                        return JsonSerializer.Serialize(new { ok = false, message = "Tên đăng nhập đã tồn tại" });
                }

                if (!string.IsNullOrWhiteSpace(email))
                {
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Users WHERE Email=@e", conn))
                    {
                        cmd.Parameters.AddWithValue("@e", email);
                        if ((int)cmd.ExecuteScalar() > 0)
                            return JsonSerializer.Serialize(new { ok = false, message = "Email đã tồn tại" });
                    }
                }

                if (!string.IsNullOrWhiteSpace(phone))
                {
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Users WHERE Phone=@p", conn))
                    {
                        cmd.Parameters.AddWithValue("@p", phone);
                        if ((int)cmd.ExecuteScalar() > 0)
                            return JsonSerializer.Serialize(new { ok = false, message = "Số điện thoại đã tồn tại" });
                    }
                }

                using (var cmd = new SqlCommand(
                    "INSERT INTO dbo.Users (Username, Email, Phone, Password) VALUES (@u, @e, @p, @pw)", conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@e", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@p", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);
                    cmd.Parameters.AddWithValue("@pw", password);
                    cmd.ExecuteNonQuery();
                }
            }

            return JsonSerializer.Serialize(new { ok = true, message = "Đăng ký thành công." });
        }
        catch (Exception ex)
        {
            Console.WriteLine("[DB ERROR] " + ex);
            return JsonSerializer.Serialize(new { ok = false, message = "Lỗi: " + ex.Message });
        }
    }

    private string HandleLogin(Dictionary<string, object> d)
    {
        string identifier = d.TryGetValue("identifier", out var id) ? id?.ToString() : "";
        string username = d.TryGetValue("username", out var u) ? u?.ToString() : "";
        string password = d.TryGetValue("password", out var pw) ? pw?.ToString() : "";


        if (string.IsNullOrWhiteSpace(identifier) && !string.IsNullOrWhiteSpace(username))
            identifier = username;

        if (string.IsNullOrWhiteSpace(identifier) || string.IsNullOrWhiteSpace(password))
            return JsonSerializer.Serialize(new { ok = false, message = "Các ô không được để trống" });
        try
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
               @"SELECT TOP 1 UserId
             FROM dbo.Users
             WHERE (Username = @k OR Email = @k OR Phone = @k)
             AND Password = @pw", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@k", identifier);
                cmd.Parameters.AddWithValue("@pw", password);

                var result = cmd.ExecuteScalar();

                if (result == null)
                {
                    return JsonSerializer.Serialize(new { ok = false, message = "Sai mật khẩu hoặc tài khoản không tồn tại" });
                }

                int userId = Convert.ToInt32(result);

                return JsonSerializer.Serialize(new
                {
                    ok = true,
                    userId = userId,
                    message = "Đăng nhập thành công"
                });
            }
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { ok = false, message = ex.Message });
        }
    }
    private string HandleProfile(Dictionary<string, object> d)
    {
        string id = d.TryGetValue("identifier", out var v) ? v?.ToString() : "";
        if (string.IsNullOrWhiteSpace(id))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu identifier" });

        try
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"
            SELECT TOP 1 
                Username,
                Email,
                Phone,
                FullName,
                Birthday,
                AvatarBase64
            FROM dbo.Users
            WHERE Username=@k OR Email=@k OR Phone=@k", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@k", id);

                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read())
                        return JsonSerializer.Serialize(new { ok = false, message = "Không tìm thấy người dùng" });

                    var resp = new
                    {
                        ok = true,
                        message = "OK",
                        username = rd["Username"]?.ToString() ?? "",
                        email = rd["Email"]?.ToString() ?? "",
                        phone = rd["Phone"]?.ToString() ?? "",
                        fullname = rd["FullName"]?.ToString() ?? "",
                        dob = rd["Birthday"] == DBNull.Value
                                ? ""
                                : ((DateTime)rd["Birthday"]).ToString("yyyy-MM-dd"),
                        avatar = rd["AvatarBase64"] == DBNull.Value
                                ? ""
                                : rd["AvatarBase64"].ToString()
                    };
                    return JsonSerializer.Serialize(resp);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[DB ERROR] " + ex);
            return JsonSerializer.Serialize(new { ok = false, message = "Lỗi: " + ex.Message });
        }
    }



    private string HandleUpdateProfile(Dictionary<string, object> d)
    {
        string userId = d.TryGetValue("UserId", out var u) ? u?.ToString() : "";
        if (string.IsNullOrWhiteSpace(userId))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu userId" });

        string fullName = d.TryGetValue("FullName", out var fn) ? fn?.ToString() : "";
        string email = d.TryGetValue("Email", out var em) ? em?.ToString() : "";
        string phone = d.TryGetValue("Phone", out var ph) ? ph?.ToString() : "";
        string dob = d.TryGetValue("Dob", out var bd) ? bd?.ToString() : "";

        try
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (!string.IsNullOrWhiteSpace(email))
                {
                    using (var c = new SqlCommand(
                        "SELECT COUNT(*) FROM Users WHERE Email=@e AND UserId<>@id", conn))
                    {
                        c.Parameters.AddWithValue("@e", email);
                        c.Parameters.AddWithValue("@id", userId);
                        if ((int)c.ExecuteScalar() > 0)
                            return JsonSerializer.Serialize(new { ok = false, message = "Email đã tồn tại" });
                    }
                }
                if (!string.IsNullOrWhiteSpace(phone))
                {
                    using (var c = new SqlCommand(
                        "SELECT COUNT(*) FROM Users WHERE Phone=@p AND UserId<>@id", conn))
                    {
                        c.Parameters.AddWithValue("@p", phone);
                        c.Parameters.AddWithValue("@id", userId);
                        if ((int)c.ExecuteScalar() > 0)
                            return JsonSerializer.Serialize(new { ok = false, message = "Số điện thoại đã tồn tại" });
                    }
                }

                string sql;
                sql = @"UPDATE Users SET FullName=@FN, Email=@E, Phone=@P,
                     Birthday=@BD WHERE UserId=@ID";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FN", string.IsNullOrWhiteSpace(fullName) ? (object)DBNull.Value : fullName);
                    cmd.Parameters.AddWithValue("@E", string.IsNullOrWhiteSpace(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@P", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);
                    cmd.Parameters.AddWithValue("@BD", string.IsNullOrWhiteSpace(dob) ? (object)DBNull.Value : dob);
                    cmd.Parameters.AddWithValue("@ID", userId);

                    cmd.ExecuteNonQuery();
                }

                return JsonSerializer.Serialize(new { ok = true, message = "Cập nhật thành công" });
            }
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { ok = false, message = ex.Message });
        }
    }

    private string HandleCreateExam(string rawJson)
    {
        QuizPackage pkg;
        try
        {
            pkg = JsonSerializer.Deserialize<QuizPackage>(rawJson);
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { ok = false, message = "JSON lỗi: " + ex.Message });
        }

        if (pkg == null || pkg.Questions == null || pkg.Questions.Count == 0)
            return JsonSerializer.Serialize(new { ok = false, message = "Không có câu hỏi" });

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    int idDeThi;
                    using (var cmd = new SqlCommand(@"
                    INSERT INTO dbo.DeThi (TenDeThi, SoCau, UserId)
                    VALUES (@t, @c, @u);
                    SELECT SCOPE_IDENTITY();", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@t", pkg.TenBo);
                        cmd.Parameters.AddWithValue("@c", pkg.Questions.Count);
                        cmd.Parameters.AddWithValue("@u", pkg.UserId);
                        idDeThi = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    
                    foreach (var q in pkg.Questions)
                    {
                        int idQ;

                        using (var cmd = new SqlCommand(@"
                        INSERT INTO dbo.Question
                        (NoiDung, DapAnDung, DapAnSai1, DapAnSai2, DapAnSai3, ImageBase64, UserId)
                        VALUES (@n, @d, @s1, @s2, @s3, @img, @u);
                        SELECT SCOPE_IDENTITY();", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@n", q.NoiDung);
                            cmd.Parameters.AddWithValue("@d", q.DapAnDung);
                            cmd.Parameters.AddWithValue("@s1", q.Sai1);
                            cmd.Parameters.AddWithValue("@s2", q.Sai2);
                            cmd.Parameters.AddWithValue("@s3", q.Sai3);
                            cmd.Parameters.AddWithValue("@img", (object)q.ImageBase64 ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@u", pkg.UserId);

                            idQ = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                        
                        using (var cmd = new SqlCommand(@"
                        INSERT INTO dbo.DeThi_CauHoi (IdDeThi, IdCauHoi)
                        VALUES (@d, @q)", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@d", idDeThi);
                            cmd.Parameters.AddWithValue("@q", idQ);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    return JsonSerializer.Serialize(new { ok = true, idDeThi, message = "Tạo đề thành công" });
                }
            }
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { ok = false, message = ex.Message });
        }
    }
    private string HandleGetMyQuiz(Dictionary<string, object> d)
    {
        string id = d.TryGetValue("userId", out var v) ? v?.ToString() : "";
        if (string.IsNullOrWhiteSpace(id))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu userId" });

        try
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                @"SELECT IdDeThi, TenDeThi, SoCau, NgayTao 
              FROM dbo.DeThi 
              WHERE UserId = @u
              ORDER BY IdDeThi DESC", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@u", id);

                var list = new List<object>();

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new
                        {
                            id = rd.GetInt32(0),
                            name = rd.GetString(1),
                            total = rd.GetInt32(2),
                            date = rd.GetDateTime(3).ToString("yyyy-MM-dd HH:mm")
                        });
                    }
                }
                return JsonSerializer.Serialize(new { ok = true, data = list });
            }
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { ok = false, message = ex.Message });
        }
    }
    private string HandleDeleteQuiz(Dictionary<string, object> d)
    {
        string id = d.TryGetValue("idDeThi", out var v) ? v?.ToString() : "";
        if (string.IsNullOrWhiteSpace(id))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu idDeThi" });

        try
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                @"DELETE FROM dbo.DeThi WHERE IdDeThi=@id", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);

                int n = cmd.ExecuteNonQuery();
                if (n == 0)
                    return JsonSerializer.Serialize(new { ok = false, message = "Không tìm thấy bộ đề" });

                return JsonSerializer.Serialize(new { ok = true, message = "Đã xóa" });
            }
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { ok = false, message = ex.Message });
        }
    }

    private string HandleGetQuizDetails(Dictionary<string, object> d)
    {
        string quizIdStr = d.TryGetValue("quizId", out var v) ? v?.ToString() : "";
        if (string.IsNullOrWhiteSpace(quizIdStr))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu quizId" });

        try
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
                SELECT q.Id, q.NoiDung, q.DapAnDung, q.DapAnSai1, q.DapAnSai2, q.DapAnSai3, q.ImageBase64
                FROM dbo.Question q
                INNER JOIN dbo.DeThi_CauHoi dc ON q.Id = dc.IdCauHoi
                WHERE dc.IdDeThi = @quizId
                ORDER BY dc.IdCauHoi";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@quizId", quizIdStr);

                    var questions = new List<object>();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            questions.Add(new
                            {
                                Id = reader.GetInt32(0),
                                NoiDung = reader.GetString(1),
                                DapAnDung = reader.GetString(2),
                                DapAnSai1 = reader.GetString(3),
                                DapAnSai2 = reader.GetString(4),
                                DapAnSai3 = reader.GetString(5),
                                ImageBase64 = reader.IsDBNull(6) ? null : reader.GetString(6)
                            });
                        }
                    }

                    if (questions.Count == 0)
                    {
                        return JsonSerializer.Serialize(new
                        {
                            ok = false,
                            message = "Không tìm thấy câu hỏi cho bộ quiz này"
                        });
                    }

                    return JsonSerializer.Serialize(new
                    {
                        ok = true,
                        message = "OK",
                        questions = questions
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[DB ERROR] " + ex);
            return JsonSerializer.Serialize(new { ok = false, message = "Lỗi: " + ex.Message });
        }
    }
    private string HandleCreateRoom(Dictionary<string, object> d)
    {
        string userIdStr = d.TryGetValue("userId", out var u) ? u?.ToString() : "";
        string quizIdStr = d.TryGetValue("quizId", out var q) ? q?.ToString() : "";
        string roomId = d.TryGetValue("roomId", out var r) ? r?.ToString() : "";

        if (string.IsNullOrWhiteSpace(userIdStr) ||
            string.IsNullOrWhiteSpace(quizIdStr) ||
            string.IsNullOrWhiteSpace(roomId))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu thông tin" });

        if (!int.TryParse(userIdStr, out int userId) ||
            !int.TryParse(quizIdStr, out int quizId))
            return JsonSerializer.Serialize(new { ok = false, message = "userId/quizId không hợp lệ" });

        lock (roomsLock)
        {
            rooms[roomId] = new RoomInfo
            {
                HostUserId = userId,
                QuizId = quizId,
                CurrentQuestionIndex = -1, 
                QuestionStartTime = null, 
                QuestionDurationSeconds = 20  
            };
        }

        return JsonSerializer.Serialize(new
        {
            ok = true,
            message = "Tạo phòng thành công",
            roomId = roomId,
            quizId = quizId
        });
    }


    private string HandleJoinRoom(Dictionary<string, object> d)
    {
        string roomId = d.TryGetValue("roomId", out var r) ? r?.ToString() : "";

        if (string.IsNullOrWhiteSpace(roomId))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu roomId" });

        lock (roomsLock)
        {
            if (!rooms.ContainsKey(roomId))
                return JsonSerializer.Serialize(new { ok = false, message = "Phòng không tồn tại" });

            rooms[roomId].PlayerCount++;

            return JsonSerializer.Serialize(new
            {
                ok = true,
                message = "Vào phòng thành công",
                quizId = rooms[roomId].QuizId
            });
        }
    }

    private string HandleRoomGetState(Dictionary<string, object> d)
    {
        string roomId = d.TryGetValue("roomId", out var r) ? r?.ToString() : "";
        if (string.IsNullOrWhiteSpace(roomId))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu roomId" });

        lock (roomsLock)
        {
            if (!rooms.TryGetValue(roomId, out var roomInfo))
                return JsonSerializer.Serialize(new { ok = false, message = "Phòng không tồn tại" });

            int timeLeft = 0;
            if (roomInfo.QuestionStartTime.HasValue)
            {
                double elapsed = (DateTime.UtcNow - roomInfo.QuestionStartTime.Value).TotalSeconds;
                timeLeft = roomInfo.QuestionDurationSeconds - (int)elapsed;
            }
            if (timeLeft < 0) timeLeft = 0;

            return JsonSerializer.Serialize(new
            {
                ok = true,
                currentQuestionIndex = roomInfo.CurrentQuestionIndex,
                timeLeftSeconds = timeLeft,
                durationSeconds = roomInfo.QuestionDurationSeconds,
                playerCount = roomInfo.PlayerCount,
                message = "Trạng thái phòng"
            });
        }
    }





    private static string ReadLine(NetworkStream stream)
    {
        var sb = new StringBuilder();
        var buf = new byte[1024];
        while (true)
        {
            int n = stream.Read(buf, 0, buf.Length);
            if (n <= 0) break;
            sb.Append(Encoding.UTF8.GetString(buf, 0, n));
            if (buf[n - 1] == (byte)'\n') break;
        }
        return sb.ToString().TrimEnd('\r', '\n');
    }

    private static void WriteLine(NetworkStream stream, string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text + "\n");
        stream.Write(bytes, 0, bytes.Length);
    }

    private void EnsureDb()
    {
        try
        {
            var csNoDb = connectionString
                .Replace("Database=QuizDB;", "")
                .Replace("Initial Catalog=QuizDB;", "");

            using (var conn = new SqlConnection(csNoDb))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "IF DB_ID('QuizDB') IS NULL CREATE DATABASE QuizDB;", conn))
                    cmd.ExecuteNonQuery();
            }

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                IF OBJECT_ID('dbo.Users','U') IS NULL
                BEGIN
                    CREATE TABLE dbo.Users(
                        UserId INT IDENTITY(1,1) PRIMARY KEY,
                        Username NVARCHAR(50) NOT NULL UNIQUE,
                        Email NVARCHAR(100) NULL UNIQUE,
                        Phone NVARCHAR(20) NULL UNIQUE,
                        Password NVARCHAR(64) NOT NULL,           
                        FullName NVARCHAR(150) NULL,
                        AvatarBase64 NVARCHAR(MAX) NULL,
                        Birthday DATE NULL
                    );
                END;

                IF OBJECT_ID('dbo.Question','U') IS NULL
                BEGIN
                    CREATE TABLE dbo.Question(
                        Id INT IDENTITY(1,1) PRIMARY KEY,
                        NoiDung NVARCHAR(500) NOT NULL,
                        DapAnDung NVARCHAR(200) NOT NULL,
                        DapAnSai1 NVARCHAR(200) NOT NULL,
                        DapAnSai2 NVARCHAR(200) NOT NULL,
                        DapAnSai3 NVARCHAR(200) NOT NULL,
                        ImageBase64 NVARCHAR(MAX) NULL,
                        UserId INT NOT NULL,
                        FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId)
                    );
                END;

                IF OBJECT_ID('dbo.DeThi','U') IS NULL
                BEGIN
                    CREATE TABLE dbo.DeThi(
                        IdDeThi INT IDENTITY(1,1) PRIMARY KEY,
                        TenDeThi NVARCHAR(200) NOT NULL,
                        SoCau INT NOT NULL,
                        NgayTao DATETIME DEFAULT GETDATE(),
                        UserId INT NOT NULL,
                        FOREIGN KEY (UserId) REFERENCES dbo.Users(UserId)
                    );
                END;

                IF OBJECT_ID('dbo.DeThi_CauHoi','U') IS NULL
                BEGIN
                    CREATE TABLE dbo.DeThi_CauHoi(
                        IdDeThi INT NOT NULL,
                        IdCauHoi INT NOT NULL,
                        PRIMARY KEY (IdDeThi, IdCauHoi),
                        FOREIGN KEY (IdDeThi) REFERENCES dbo.DeThi(IdDeThi) ON DELETE CASCADE,
                        FOREIGN KEY (IdCauHoi) REFERENCES dbo.Question(Id) ON DELETE CASCADE
                    );
                END;
                ";
                using (var cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
            }

            Console.WriteLine("[SERVER] QuizDB schema ready.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("[SERVER] EnsureDb error: " + ex.Message);
        }
    }

    public class QuestionModel
    {
        public string NoiDung { get; set; }
        public string DapAnDung { get; set; }
        public string Sai1 { get; set; }
        public string Sai2 { get; set; }
        public string Sai3 { get; set; }
        public string ImageBase64 { get; set; }
    }
    public class QuizPackage
    {
        public string action { get; set; }
        public int UserId { get; set; }
        public string TenBo { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }
}
