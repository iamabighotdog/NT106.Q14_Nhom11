using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class leaderboard : Form
    {
        private tcpClient client;
        private string currentRoomId;
        private Timer refreshTimer;
        private bool autoRefresh = true;

        // Constructor nhận roomId
        public leaderboard(string roomId)
        {
            InitializeComponent();
            client = new tcpClient();
            currentRoomId = roomId;

            // Setup timer để tự động refresh
            refreshTimer = new Timer();
            refreshTimer.Interval = 3000; // Refresh mỗi 3 giây
            refreshTimer.Tick += RefreshTimer_Tick;

            // Load dữ liệu lần đầu
            LoadLeaderboard();

            // Bắt đầu auto refresh
            if (autoRefresh)
            {
                refreshTimer.Start();
            }

            // Setup event handlers
            back.Click += Back_Click;
            this.FormClosing += Leaderboard_FormClosing;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            try
            {
                string response = client.SendRoomGetLeaderboard(currentRoomId);
                var result = JsonSerializer.Deserialize<LeaderboardResponse>(response);

                if (result.ok)
                {
                    DisplayLeaderboard(result.leaderboard);
                }
                else
                {
                    // Nếu lỗi, có thể dừng timer
                    MessageBox.Show($"Lỗi: {result.message}", "Thông báo",
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
            // Clear flowLayoutPanel trước
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

            // Hiển thị từng người chơi
            for (int i = 0; i < players.Count; i++)
            {
                var player = players[i];
                var banner = new playerBanner();

                // Set dữ liệu (không có avatar vì chưa có API lấy avatar riêng)
                banner.SetPlayerData(
                    ranking: i + 1,
                    playerName: player.username,
                    score: player.score,
                    avatarBase64: null // Tạm thời null, có thể thêm sau
                );

                // Highlight nếu là người chơi hiện tại
                if (player.userId == Global.UserId)
                {
                    banner.HighlightCurrentPlayer();
                }

                // Thêm margin
                banner.Margin = new Padding(0, 5, 0, 5);

                flowLayoutPanel1.Controls.Add(banner);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Leaderboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dừng timer khi đóng form
            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Dispose();
            }
        }

        // Classes để deserialize response từ server
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
    }
}