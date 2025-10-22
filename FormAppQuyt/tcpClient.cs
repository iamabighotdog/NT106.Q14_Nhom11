using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace FormAppQuyt
{
    internal class tcpClient
    {
        private string serverIp = "127.0.0.1"; 
        private int serverPort = 3636; 

        public string SendRegisterData(string username, string email, string phone, string hashedPassword)
        {
            try
            {
                using (TcpClient client = new TcpClient(serverIp, serverPort))
                using (NetworkStream stream = client.GetStream())
                {
                    var requestData = new
                    {
                        action = "register",
                        username = username,
                        email = email,
                        phone = phone,
                        password = hashedPassword
                    };
                    string jsonData = JsonSerializer.Serialize(requestData);
                    byte[] dataToSend = Encoding.UTF8.GetBytes(jsonData);

                    stream.Write(dataToSend, 0, dataToSend.Length);

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    return response; 
                }
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}
