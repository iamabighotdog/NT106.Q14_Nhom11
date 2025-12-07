using FormAppQuyt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;


internal class tcpClient
{
    private string serverIp = "127.0.0.1";
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
                return ReadResponse(stream);
            }
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { ok = false, message = ex.Message });
        }
    }
    private string ReadResponse(NetworkStream stream)
    {
        using (var ms = new MemoryStream())
        {
            var buffer = new byte[4096];
            int read;

            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);

                if (!stream.DataAvailable)
                    break;
            }

            return Encoding.UTF8.GetString(ms.ToArray());
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
    public string SendGetMyQuiz(int userId)
    {
        var data = new
        {
            action = "get_my_quiz",
            userId = userId
        };
        return SendToServer(data);
    }
    public string SendDeleteQuiz(int idDeThi)
    {
        var data = new
        {
            action = "delete_quiz",
            idDeThi = idDeThi
        };
        return SendToServer(data);
    }
    public string SendCreateQuiz(int userId, string tenBo, List<QuizQuestion> questions)
    {
        var data = new
        {
            action = "create_exam",
            UserId = userId,
            TenBo = tenBo,
            Questions = questions
        };
        return SendToServer(data);
    }
    public string SendUpdateProfile(int userId, string fullName, string email, string phone, string dob)
    {
        var data = new
        {
            action = "update_profile",
            UserId = userId,
            FullName = fullName,
            Email = email,
            Phone = phone,
            Dob = dob,
        };
        return SendToServer(data);
    }
    public string SendUpdateAvatar(int userId, string avatarBase64)
    {
        var data = new
        {
            action = "update_avatar",
            userId = userId,
            avatar = avatarBase64
        };
        return SendToServer(data);
    }

    public string SendGetQuizDetails(int quizId)
    {
        var data = new
        {
            action = "get_quiz_details",
            quizId = quizId
        };
        return SendToServer(data);
    }

    public string SendCreateRoom(int userId, int quizId, string roomId)
    {
        var data = new
        {
            action = "create_room",
            userId = userId,
            quizId = quizId,
            roomId = roomId
        };
        return SendToServer(data);
    }
}
