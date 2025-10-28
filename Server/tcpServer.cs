using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
        @"Server=.;Database=UserAuthDB;Integrated Security=True;TrustServerCertificate=True;";

    // === Helper: lấy giá trị từ Dictionary mà không double-lookup ===
    private static string GetOrEmpty(Dictionary<string, string> d, string key)
    {
        return (d != null && d.TryGetValue(key, out var v) && v != null) ? v : string.Empty;
    }

    public void Start()
    {
        listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        running = true;
        Console.WriteLine($"[SERVER] Listening on port {port}...");

        while (running)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("[SERVER] Client connected!");
            var t = new Thread(() => HandleClient(client)) { IsBackground = true };
            t.Start();
        }
    }

    private void HandleClient(TcpClient client)
    {
        using (client)
        using (var stream = client.GetStream())
        using (var reader = new StreamReader(stream, Encoding.UTF8))
        using (var writer = new StreamWriter(stream, new UTF8Encoding(false)) { AutoFlush = true, NewLine = "\n" })
        {
            try
            {
                while (true)
                {
                    string line = reader.ReadLine();     // 1 dòng JSON từ client
                    if (line == null) break;

                    Console.WriteLine("[SERVER] Received: " + line);

                    Dictionary<string, string> data = null;
                    try { data = JsonSerializer.Deserialize<Dictionary<string, string>>(line); }
                    catch
                    {
                        writer.WriteLine(JsonSerializer.Serialize(new { ok = false, message = "JSON không hợp lệ" }));
                        continue;
                    }

                    string response = ProcessRequest(data);
                    writer.WriteLine(response);          // trả 1 dòng JSON
                    Console.WriteLine("[SERVER] Sent: " + response);
                }
            }
            catch (Exception ex)
            {
                var err = JsonSerializer.Serialize(new { ok = false, message = "Lỗi: " + ex.Message });
                try { writer.WriteLine(err); } catch { /* ignore */ }
            }
        }
        Console.WriteLine("[SERVER] Client disconnected.");
    }

    private string ProcessRequest(Dictionary<string, string> data)
    {
        if (data == null || !data.TryGetValue("action", out var actionRaw))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu action" });

        string action = (actionRaw ?? string.Empty).ToLowerInvariant();

        if (action == "register") return HandleRegister(data);
        if (action == "login") return HandleLogin(data);
        if (action == "profile") return HandleProfile(data);
        if (action == "logout") return JsonSerializer.Serialize(new { ok = true, message = "Đăng xuất" });

        return JsonSerializer.Serialize(new { ok = false, message = "Action không hỗ trợ" });
    }

    private string HandleRegister(Dictionary<string, string> d)
    {
        string username = GetOrEmpty(d, "username");
        string password = GetOrEmpty(d, "password");
        string email = GetOrEmpty(d, "email");
        string phone = GetOrEmpty(d, "phone");

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return JsonSerializer.Serialize(new { ok = false, message = "Các ô không được để trống" });

        try
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // check username
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@u", conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    if ((int)cmd.ExecuteScalar() > 0)
                        return JsonSerializer.Serialize(new { ok = false, message = "Tên đăng nhập đã tồn tại" });
                }

                // check email
                if (!string.IsNullOrWhiteSpace(email))
                {
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email=@e", conn))
                    {
                        cmd.Parameters.AddWithValue("@e", email);
                        if ((int)cmd.ExecuteScalar() > 0)
                            return JsonSerializer.Serialize(new { ok = false, message = "Email đã tồn tại" });
                    }
                }

                // check phone
                if (!string.IsNullOrWhiteSpace(phone))
                {
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Phone=@p", conn))
                    {
                        cmd.Parameters.AddWithValue("@p", phone);
                        if ((int)cmd.ExecuteScalar() > 0)
                            return JsonSerializer.Serialize(new { ok = false, message = "Số điện thoại đã tồn tại" });
                    }
                }

                // insert
                using (var cmd = new SqlCommand(
                    "INSERT INTO Users (Username, Email, Phone, Password) VALUES (@u, @e, @p, @pw)", conn))
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
            return JsonSerializer.Serialize(new { ok = false, message = "Lỗi: " + ex.Message });
        }
    }

    private string HandleLogin(Dictionary<string, string> d)
    {
        string identifier = GetOrEmpty(d, "identifier");
        if (string.IsNullOrEmpty(identifier))
            identifier = GetOrEmpty(d, "username");

        string password = GetOrEmpty(d, "password");

        if (string.IsNullOrWhiteSpace(identifier) || string.IsNullOrWhiteSpace(password))
            return JsonSerializer.Serialize(new { ok = false, message = "Các ô không được để trống" });

        try
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM Users
                               WHERE (Username=@k OR Email=@k OR Phone=@k) AND Password=@pw";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@k", identifier);
                    cmd.Parameters.AddWithValue("@pw", password);

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                        return JsonSerializer.Serialize(new { ok = true, message = "Đăng Nhập Thành Công." });
                    else
                        return JsonSerializer.Serialize(new { ok = false, message = "Sai mật khẩu hoặc tên đăng nhập không tồn tại." });
                }
            }
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { ok = false, message = "Lỗi: " + ex.Message });
        }
    }

    private string HandleProfile(Dictionary<string, string> d)
    {
        string id = GetOrEmpty(d, "identifier");
        if (string.IsNullOrWhiteSpace(id))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu identifier" });

        try
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT TOP 1 Username, Email, Phone
                               FROM Users
                               WHERE Username=@k OR Email=@k OR Phone=@k";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@k", id);

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            return JsonSerializer.Serialize(new
                            {
                                ok = true,
                                message = "OK",
                                username = rd["Username"]?.ToString() ?? "",
                                email = rd["Email"]?.ToString() ?? "",
                                phone = rd["Phone"]?.ToString() ?? ""
                            });
                        }
                        else
                        {
                            return JsonSerializer.Serialize(new { ok = false, message = "Không tìm thấy người dùng" });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { ok = false, message = "Lỗi: " + ex.Message });
        }
    }
}
