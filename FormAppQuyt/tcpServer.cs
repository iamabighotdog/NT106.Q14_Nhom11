using System;
using System.Collections.Generic;
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

    private Dictionary<string, User> users = new Dictionary<string, User>();

    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public void Start()
    {
        LoadUsers();

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
        using (NetworkStream stream = client.GetStream())
        {
            byte[] buffer = new byte[2048];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine("[SERVER] Received: " + json);

            try
            {
                var data = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                string response = ProcessRequest(data);
                byte[] respBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(respBytes, 0, respBytes.Length);
                Console.WriteLine("[SERVER] Sent: " + response);
            }
            catch (Exception ex)
            {
                string error = JsonSerializer.Serialize(new { status = "error", message = ex.Message });
                byte[] respBytes = Encoding.UTF8.GetBytes(error);
                stream.Write(respBytes, 0, respBytes.Length);
            }
        }

        client.Close();
        Console.WriteLine("[SERVER] Client disconnected.");
    }

    private string ProcessRequest(Dictionary<string, string> data)
    {
        if (data == null || !data.ContainsKey("action"))
            return JsonSerializer.Serialize(new { status = "error", message = "Invalid JSON format" });

        string action = data["action"].ToLower();

        switch (action)
        {
            case "register":
                return HandleRegister(data);
            case "login":
                return HandleLogin(data);
            default:
                return JsonSerializer.Serialize(new { status = "error", message = "Unknown action" });
        }
    }


    private string HandleRegister(Dictionary<string, string> data)
    {
        if (!data.ContainsKey("username") || !data.ContainsKey("password"))
            return JsonSerializer.Serialize(new { status = "error", message = "Missing username or password" });

        string username = data["username"];
        string password = data["password"];
        string email = data.ContainsKey("email") ? data["email"] : "";
        string phone = data.ContainsKey("phone") ? data["phone"] : "";

        if (users.ContainsKey(username))
            return JsonSerializer.Serialize(new { status = "error", message = "Username already exists" });

        users[username] = new User { Username = username, Password = password, Email = email, Phone = phone };
        SaveUsers();

        return JsonSerializer.Serialize(new { status = "ok", message = "Register successful" });
    }

    private string HandleLogin(Dictionary<string, string> data)
    {
        if (!data.ContainsKey("username") || !data.ContainsKey("password"))
            return JsonSerializer.Serialize(new { status = "error", message = "Missing username or password" });

        string username = data["username"];
        string password = data["password"];

        if (users.TryGetValue(username, out User user))
        {
            if (user.Password == password)
                return JsonSerializer.Serialize(new { status = "ok", message = "Login successful" });
            else
                return JsonSerializer.Serialize(new { status = "error", message = "Wrong password" });
        }
        else
        {
            return JsonSerializer.Serialize(new { status = "error", message = "User not found" });
        }
    }

    private void SaveUsers()
    {
        File.WriteAllText("users.json", JsonSerializer.Serialize(users));
    }

    private void LoadUsers()
    {
        if (File.Exists("users.json"))
        {
            users = JsonSerializer.Deserialize<Dictionary<string, User>>(File.ReadAllText("users.json"));
        }
    }
}
