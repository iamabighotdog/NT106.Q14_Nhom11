using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using FormAppQuyt;

internal class tcpClient
{
    private readonly string serverIp = "127.0.0.1";
    private readonly int serverPort = 3636;

    private string SendToServer(object data)
    {
        try
        {
            using (var client = new TcpClient())
            {
                client.SendTimeout = 5000;
                client.ReceiveTimeout = 5000;

                client.Connect(serverIp, serverPort);

                using (NetworkStream stream = client.GetStream())
                {
                    string jsonData = JsonSerializer.Serialize(data) + "\n";
                    byte[] bytes = Encoding.UTF8.GetBytes(jsonData);
                    stream.Write(bytes, 0, bytes.Length);

                    return ReadLine(stream);
                }
            }
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { ok = false, message = ex.Message });
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

    public string SendRegisterData(string username, string email, string phone, string hashedPassword)
    {
        var data = new
        {
            action = "register",
            username,
            email,
            phone,
            password = hashedPassword
        };
        return SendToServer(data);
    }

    public string SendLoginData(string usernameOrEmailOrPhone, string hashedPassword)
    {
        var data = new
        {
            action = "login",
            identifier = usernameOrEmailOrPhone,
            password = hashedPassword
        };
        return SendToServer(data);
    }

    public string SendProfileData(string identifier)
    {
        var data = new
        {
            action = "profile",
            identifier
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
            Dob = dob
        };
        return SendToServer(data);
    }

    public string SendUpdateAvatar(int userId, string avatarBase64)
    {
        var data = new
        {
            action = "update_avatar",
            userId,
            avatar = avatarBase64
        };
        return SendToServer(data);
    }

    public string SendGetMyQuiz(int userId)
    {
        var data = new { action = "get_my_quiz", userId };
        return SendToServer(data);
    }

    public string SendDeleteQuiz(int idDeThi)
    {
        var data = new { action = "delete_quiz", idDeThi };
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

    public string SendGetQuizDetails(int quizId)
    {
        var data = new { action = "get_quiz_details", quizId };
        return SendToServer(data);
    }

    public string SendCreateRoom(int userId, int quizId, string roomId)
    {
        var data = new { action = "create_room", userId, quizId, roomId };
        return SendToServer(data);
    }

    public string SendJoinRoom(string roomId)
    {
        return SendJoinRoom(roomId, Global.UserId);
    }

    public string SendJoinRoom(string roomId, int userId)
    {
        var data = new { action = "join_room", roomId, userId };
        return SendToServer(data);
    }

    public string SendRoomStartQuestion(string roomId, int questionIndex, int durationSeconds)
    {
        var data = new { action = "room_start_question", roomId, questionIndex, durationSeconds };
        return SendToServer(data);
    }

    public string SendRoomGetState(string roomId)
    {
        var data = new { action = "room_get_state", roomId };
        return SendToServer(data);
    }

    public string SendSubmitAnswer(string roomId, int userId, string answer)
    {
        var data = new { action = "submit_answer", roomId, userId, answer };
        return SendToServer(data);
    }

    public string SendRoomGetLeaderboard(string roomId)
    {
        var data = new { action = "room_get_leaderboard", roomId };
        return SendToServer(data);
    }
}
