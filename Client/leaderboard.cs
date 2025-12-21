using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace FormAppQuyt
{
    public partial class leaderboard : Form
    {
        private TcpSessionClient _session;
        private string currentRoomId;
        private Timer refreshTimer;
        private bool autoRefresh = true;
        private bool _loading = false;

        public leaderboard(string roomId)
        {
            InitializeComponent();
            _session = new TcpSessionClient();
            _session.Connect();
            currentRoomId = roomId;


            refreshTimer = new Timer();
            refreshTimer.Interval = 3000;
            refreshTimer.Tick += RefreshTimer_Tick;

            _ = LoadLeaderboardAsync();

            if (autoRefresh)
            {
                refreshTimer.Start();
            }

            this.FormClosing += Leaderboard_FormClosing;
        }

        private async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (_loading) return;
            _loading = true;
            try
            {
                await LoadLeaderboardAsync();
            }
            finally
            {
                _loading = false;
            }
        }



        private async Task LoadLeaderboardAsync()
        {
            try
            {
                string response = await _session.SendRoomGetLeaderboardAsync(currentRoomId);
                var result = JsonSerializer.Deserialize<LeaderboardResponse>(response);

                if (result != null && result.ok)
                {
                    DisplayLeaderboard(result.leaderboard);
                }
                else
                {
                    MessageBox.Show($"Lỗi: {result?.message}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refreshTimer?.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải bảng xếp hạng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                refreshTimer?.Stop();
            }
        }


        private void DisplayLeaderboard(List<PlayerScore> players)
        {
            flowLayoutPanel1.Controls.Clear();

            if (players == null || players.Count == 0)
            {
                Label noData = new Label
                {
                    Text = "Chưa có người chơi nào",
                    Font = new Font("Segoe UI", 14),
                    AutoSize = true,
                    ForeColor = Color.Gray,
                    Padding = new Padding(20)
                };
                flowLayoutPanel1.Controls.Add(noData);
                return;
            }

            for (int i = 0; i < players.Count; i++)
            {
                var player = players[i];
                var banner = new playerBanner();

                banner.SetPlayerData(
                    ranking: i + 1,
                    playerName: player.username,
                    score: player.score,
                    avatarBase64: null 
                );

                if (player.userId == Global.UserId)
                {
                    banner.HighlightCurrentPlayer();
                }

                banner.Margin = new Padding(0, 5, 0, 5);

                flowLayoutPanel1.Controls.Add(banner);
            }
        }
        private void Leaderboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Dispose();
            }
            _session?.Dispose();

        }

        private class LeaderboardResponse
        {
            public bool ok { get; set; }
            public List<PlayerScore> leaderboard { get; set; }
            public string message { get; set; }
        }

        private class PlayerScore
        {
            public int userId { get; set; }
            public string username { get; set; }
            public int score { get; set; }
        }

        private void back_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}