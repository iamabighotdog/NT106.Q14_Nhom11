using System;
using System.Collections.Generic;
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
        @"Server=.;Database=UserAuthDB;Integrated Security=True;TrustServerCertificate=True;";

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
            Thread t = new Thread(() => HandleClient(client));
            t.Start();
        }
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
                WriteLine(stream, JsonSerializer.Serialize(new { ok = false, message = ex.Message }));
            }
        }
        Console.WriteLine("[SERVER] Client disconnected.");
    }
    private string ProcessRequest(Dictionary<string, string> data)
    {
        if (data == null || !data.ContainsKey("action"))
            return JsonSerializer.Serialize(new { ok = false, message = "Lỗi" });

        string action = (data["action"] ?? "").ToLower();

        if (action == "register") return HandleRegister(data);
        if (action == "login") return HandleLogin(data);
        if (action == "profile") return HandleProfile(data);

        return JsonSerializer.Serialize(new { ok = false, message = "Lỗi" });
    }

    private string HandleRegister(Dictionary<string, string> data)
    {
        string username = data.ContainsKey("username") ? data["username"] : "";
        string password = data.ContainsKey("password") ? data["password"] : "";
        string email = data.ContainsKey("email") ? data["email"] : "";
        string phone = data.ContainsKey("phone") ? data["phone"] : "";

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return JsonSerializer.Serialize(new { ok = false, message = "Các ô không được để trống" });

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@u", conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                        return JsonSerializer.Serialize(new { ok = false, message = "Tên đăng nhập đã tồn tại" });
                }
                if (!string.IsNullOrWhiteSpace(email))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email=@e", conn))
                    {
                        cmd.Parameters.AddWithValue("@e", email);
                        if ((int)cmd.ExecuteScalar() > 0)
                            return JsonSerializer.Serialize(new { ok = false, message = "Email đã tồn tại" });
                    }
                }
                if (!string.IsNullOrWhiteSpace(phone))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Phone=@p", conn))
                    {
                        cmd.Parameters.AddWithValue("@p", phone);
                        if ((int)cmd.ExecuteScalar() > 0)
                            return JsonSerializer.Serialize(new { ok = false, message = "Số điện thoại đã tồn tại" });
                    }
                }
                using (SqlCommand cmd = new SqlCommand(
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

    private string HandleLogin(Dictionary<string, string> data)
    {
        string identifier = data.ContainsKey("identifier") ? data["identifier"] : "";
        string username = data.ContainsKey("username") ? data["username"] : "";
        string password = data.ContainsKey("password") ? data["password"] : "";

        if (string.IsNullOrWhiteSpace(identifier) && !string.IsNullOrWhiteSpace(username))
            identifier = username;

        if (string.IsNullOrWhiteSpace(identifier) || string.IsNullOrWhiteSpace(password))
            return JsonSerializer.Serialize(new { ok = false, message = "Các ô không được để trống" });

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE (Username = @k OR Email = @k OR Phone = @k) AND Password = @pw";
                using (SqlCommand cmd = new SqlCommand(query, conn))
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
    private string HandleProfile(Dictionary<string, string> data)
    {
        string id = data.ContainsKey("identifier") ? data["identifier"] : "";
        if (string.IsNullOrWhiteSpace(id))
            return JsonSerializer.Serialize(new { ok = false, message = "Thiếu identifier" });

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT TOP 1 Username, Email, Phone FROM Users WHERE Username=@k OR Email=@k OR Phone=@k";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@k", id);

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            string u = rd["Username"]?.ToString() ?? "";
                            string e = rd["Email"]?.ToString() ?? "";
                            string p = rd["Phone"]?.ToString() ?? "";

                            return JsonSerializer.Serialize(new
                            {
                                ok = true,
                                message = "OK",
                                username = u,
                                email = e,
                                phone = p
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
        return sb.ToString().Trim();
    }

    private static void WriteLine(NetworkStream stream, string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text + "\n");
        stream.Write(bytes, 0, bytes.Length);
    }
}
