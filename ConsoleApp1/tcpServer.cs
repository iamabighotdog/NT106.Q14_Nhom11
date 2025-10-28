
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
        ConfigurationManager.ConnectionStrings["UserAuthDB"]?.ConnectionString
        ?? @"Server=(localdb)\MSSQLLocalDB;Database=UserAuthDB;Integrated Security=True;TrustServerCertificate=True;";


    public void Start()
    {
        Console.WriteLine("[DB] Using CS: " + connectionString);
        try
        {
            EnsureDb();

            using (var test = new SqlConnection(connectionString))
            {
                test.Open();
                using (var cmd = new SqlCommand("SELECT DB_ID('UserAuthDB')", test))
                {
                    var id = cmd.ExecuteScalar();
                    Console.WriteLine("[DB] DB_ID(UserAuthDB) = " + (id == null ? "NULL" : id.ToString()));
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
                string json = ReadLine(stream);
                Console.WriteLine("[SERVER] Received: " + json);

                var data = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                string response = ProcessRequest(data);

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
    private string ProcessRequest(Dictionary<string, string> data)
    {
        if (data == null)
            return JsonSerializer.Serialize(new { ok = false, message = "Lỗi" });

        string actionRaw;
        if (!data.TryGetValue("action", out actionRaw))
            return JsonSerializer.Serialize(new { ok = false, message = "Lỗi" });

        string action = (actionRaw ?? "").Trim().ToLowerInvariant();

        if (action == "register") return HandleRegister(data);
        if (action == "login") return HandleLogin(data);
        if (action == "profile") return HandleProfile(data);
        if (action == "logout") return JsonSerializer.Serialize(new { ok = true, message = "Đăng xuất" });

        return JsonSerializer.Serialize(new { ok = false, message = "Lỗi" });
    }

    private string HandleRegister(Dictionary<string, string> d)
    {
        string username = d.TryGetValue("username", out var u) ? u : "";
        string password = d.TryGetValue("password", out var pw) ? pw : "";
        string email = d.TryGetValue("email", out var e) ? e : "";
        string phone = d.TryGetValue("phone", out var p) ? p : "";

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

    private string HandleLogin(Dictionary<string, string> d)
    {
        string identifier = d.TryGetValue("identifier", out var id) ? id : "";
        string username = d.TryGetValue("username", out var u) ? u : "";
        string password = d.TryGetValue("password", out var pw) ? pw : "";

        if (string.IsNullOrWhiteSpace(identifier) && !string.IsNullOrWhiteSpace(username))
            identifier = username;

        if (string.IsNullOrWhiteSpace(identifier) || string.IsNullOrWhiteSpace(password))
            return JsonSerializer.Serialize(new { ok = false, message = "Các ô không được để trống" });

        try
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM dbo.Users WHERE (Username=@k OR Email=@k OR Phone=@k) AND Password=@pw", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@k", identifier);
                cmd.Parameters.AddWithValue("@pw", password);

                int count = (int)cmd.ExecuteScalar();
                return count > 0
                    ? JsonSerializer.Serialize(new { ok = true, message = "Đăng Nhập Thành Công." })
                    : JsonSerializer.Serialize(new { ok = false, message = "Sai mật khẩu hoặc tên đăng nhập không tồn tại." });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[DB ERROR] " + ex);
            return JsonSerializer.Serialize(new { ok = false, message = "Lỗi: " + ex.Message });
        }
    }

    private string HandleProfile(Dictionary<string, string> d)
    {
        string id = d.TryGetValue("identifier", out var v) ? v : "";
        if (string.IsNullOrWhiteSpace(id))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu identifier" });

        try
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 Username, Email, Phone FROM dbo.Users WHERE Username=@k OR Email=@k OR Phone=@k", conn))
            {
                conn.Open();
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
                    return JsonSerializer.Serialize(new { ok = false, message = "Không tìm thấy người dùng" });
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[DB ERROR] " + ex);
            return JsonSerializer.Serialize(new { ok = false, message = "Lỗi: " + ex.Message });
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
                .Replace("Database=UserAuthDB;", string.Empty)
                .Replace("Initial Catalog=UserAuthDB;", string.Empty);

            using (var conn = new SqlConnection(csNoDb))
            {
                conn.Open();
                using (var cmd = new SqlCommand("IF DB_ID('UserAuthDB') IS NULL CREATE DATABASE UserAuthDB;", conn))
                    cmd.ExecuteNonQuery();
            }

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var sql = @"
IF OBJECT_ID('dbo.Users','U') IS NULL
BEGIN
    CREATE TABLE dbo.Users(
        UserId   INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50)  NOT NULL UNIQUE,
        Email    NVARCHAR(100) NULL UNIQUE,
        Phone NVARCHAR(20) NULL UNIQUE,
        Password NVARCHAR(64) NOT NULL,           
        FullName NVARCHAR(150) NULL,
        Birthday DATE          NULL
    );
END";
                using (var cmd = new SqlCommand(sql, conn))
                    cmd.ExecuteNonQuery();
            }

            Console.WriteLine("[SERVER] DB ready.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("[SERVER] EnsureDb error: " + ex.Message);
        }
    }
}
