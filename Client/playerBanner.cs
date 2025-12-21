using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class playerBanner : UserControl
    {
        public playerBanner()
        {
            InitializeComponent();
        }

        // Method để set dữ liệu cho banner
        public void SetPlayerData(int ranking, string playerName, int score, string avatarBase64 = null)
        {
            // Set rank
            rank.Text = $"#{ranking}";

            // Set username
            username.Text = playerName;

            // Set điểm
            point.Text = $"{score} điểm";

            // Highlight top 3 với màu sắc khác nhau
            if (ranking == 1)
            {
                this.BackColor = Color.Gold;
                rank.ForeColor = Color.DarkGoldenrod;
                username.ForeColor = Color.DarkGoldenrod;
                point.ForeColor = Color.DarkGoldenrod;
            }
            else if (ranking == 2)
            {
                this.BackColor = Color.Silver;
                rank.ForeColor = Color.Gray;
                username.ForeColor = Color.Gray;
                point.ForeColor = Color.Gray;
            }
            else if (ranking == 3)
            {
                this.BackColor = Color.FromArgb(205, 127, 50); // Bronze color
                rank.ForeColor = Color.SaddleBrown;
                username.ForeColor = Color.SaddleBrown;
                point.ForeColor = Color.SaddleBrown;
            }
            else
            {
                this.BackColor = Color.White;
                rank.ForeColor = Color.Black;
                username.ForeColor = Color.Black;
                point.ForeColor = Color.Black;
            }

            // Load avatar
            LoadAvatar(avatarBase64);
        }

        // Load avatar từ base64
        private void LoadAvatar(string avatarBase64)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(avatarBase64))
                {
                    byte[] imageBytes = Convert.FromBase64String(avatarBase64);
                    using (var ms = new MemoryStream(imageBytes))
                    using (var img = Image.FromStream(ms))
                    {
                        avatar.Image = new Bitmap(img); 
                        avatar.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                else
                {
                    // Avatar mặc định - có thể set null hoặc dùng ảnh default
                    avatar.Image = null;
                    avatar.BackColor = Color.LightGray;
                    avatar.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading avatar: {ex.Message}");
                avatar.Image = null;
                avatar.BackColor = Color.LightGray;
            }
        }

        // Highlight người chơi hiện tại với border màu xanh
        public void HighlightCurrentPlayer()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            // Thêm padding để border rõ hơn
            this.Padding = new Padding(3);
        }
    }
}