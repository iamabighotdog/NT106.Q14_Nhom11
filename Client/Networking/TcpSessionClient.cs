using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAppQuyt.Networking
{
    public class TcpSessionClient : IDisposable
    {
        private readonly string serverIp = "160.30.113.189";
        private readonly int serverPort = 3636;

        private TcpClient _client;
        private NetworkStream _stream;
        private StreamReader _reader;
        private StreamWriter _writer;
        private bool _isListening = false;

        private readonly SemaphoreSlim _io = new SemaphoreSlim(1, 1);

        public event Action<string> OnIncomingPacket;

        private static readonly Encoding Utf8NoBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        public bool IsConnected => _client != null && _client.Connected;

        public void Connect()
        {
            if (IsConnected) return;

            try
            {
                _client = new TcpClient();
                _client.Connect(serverIp, serverPort);
                _stream = _client.GetStream();
                _reader = new StreamReader(_stream, Utf8NoBom);
                _writer = new StreamWriter(_stream, Utf8NoBom) { AutoFlush = true };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được Server: " + ex.Message);
            }
        }


        public void StartListening()
        {
            if (_isListening) return;

            if (!IsConnected) Connect();
            if (!IsConnected) return;

            _isListening = true;
            Task.Run(async () =>
            {
                try
                {
                    while (_isListening && IsConnected)
                    {
                        string line = await _reader.ReadLineAsync();
                        if (line == null) break;
                        OnIncomingPacket?.Invoke(line);
                    }
                }
                catch { }
                finally { Dispose(); }
            });
        }

        public void Send(object data)
        {
            if (!IsConnected) return;
            try
            {
                string json = JsonSerializer.Serialize(data);
                lock (_writer)
                {
                    _writer.WriteLine(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Send Error: " + ex.Message);
            }
        }


        private async Task<string> SendLockedAsync(object data)
        {
            if (_isListening)
                throw new InvalidOperationException("Không thể dùng hàm Hỏi-Đáp (SendLockedAsync) khi đang ở chế độ Lắng Nghe (StartListening). Hãy dùng Send() và hứng sự kiện OnIncomingPacket.");

            if (!IsConnected) Connect();

            await _io.WaitAsync();
            try
            {
                string json = JsonSerializer.Serialize(data);
                await _writer.WriteLineAsync(json);
                string line = await _reader.ReadLineAsync();
                return line ?? JsonSerializer.Serialize(new { ok = false, message = "Disconnected" });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { ok = false, message = ex.Message });
            }
            finally
            {
                _io.Release();
            }
        }

        public Task<string> SendRoomGetStateAsync(string roomId)
            => SendLockedAsync(new { action = "room_get_state", roomId });

        public Task<string> SendSubmitAnswerAsync(string roomId, int userId, string answer)
            => SendLockedAsync(new { action = "submit_answer", roomId, userId, answer });

        public Task<string> SendRoomGetLeaderboardAsync(string roomId)
            => SendLockedAsync(new { action = "room_get_leaderboard", roomId });


        public void Dispose()
        {
            _isListening = false;
            try { _writer?.Dispose(); } catch { }
            try { _reader?.Dispose(); } catch { }
            try { _stream?.Dispose(); } catch { }
            try { _client?.Close(); } catch { }
        }
    }
}
