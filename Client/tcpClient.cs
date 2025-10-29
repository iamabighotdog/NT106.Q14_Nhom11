using System.Net.Sockets;
using System.Text;
using System;
using System.Text.Json;


internal class tcpClient
{
    private string serverIp = "192.168.2.44";
    private int serverPort = 3636;

    private string SendToServer(object data)
    {
        try
        {
            using (TcpClient client = new TcpClient(serverIp, serverPort))
            using (NetworkStream stream = client.GetStream())
            {
                string jsonData = JsonSerializer.Serialize(data) + "\n";
                byte[] bytes = Encoding.UTF8.GetBytes(jsonData);
                stream.Write(bytes, 0, bytes.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }
        }
        catch (Exception ex)
        {
            return "ERROR: " + ex.Message;
        }
    }

    public string SendRegisterData(string username, string email, string phone, string hashedPassword)
    {
        var data = new
        {
            action = "register",
            username = username,
            email = email,
            phone = phone,
            password = hashedPassword
        };
        return SendToServer(data);
    }

    public string SendLoginData(string username, string hashedPassword)
    {
        var data = new
        {
            action = "login",
            username = username,
            password = hashedPassword
        };
        return SendToServer(data);
    }
    public string SendProfileData(string identifier)
    {
        var data = new
        {
            action = "profile",
            identifier = identifier
        };
        return SendToServer(data);
    }
}