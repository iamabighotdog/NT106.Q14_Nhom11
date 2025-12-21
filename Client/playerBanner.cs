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
            this.Resize += (s, e) =>
            {
                point.Width = 180;
                point.Left = this.Width - point.Width - 15;
            };
        }

        public void SetPlayerData(int ranking, string playerName, int score, string avatarBase64 = null)
        {

            rank.Text = $"#{ranking}";

            username.Text = playerName;

            point.Text = $"{score} điểm";
            point.AutoSize = false;
            point.TextAlignment = ContentAlignment.MiddleRight;

            point.Width = 180;
            point.Left = this.Width - point.Width - 15;
            point.Top = 46;

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
                this.BackColor = Color.FromArgb(205, 127, 50);
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
            LoadAvatar(avatarBase64);
        }

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
                    var def = FormAppQuyt.Utils.AvatarCache.GetDefault();
                    if (!string.IsNullOrWhiteSpace(def))
                    {
                        byte[] imageBytes = Convert.FromBase64String(def);
                        using (var ms = new MemoryStream(imageBytes))
                        using (var img = Image.FromStream(ms))
                        {
                            avatar.Image = new Bitmap(img);
                            avatar.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    else
                    {
                        avatar.Image = null;
                        avatar.BackColor = Color.LightGray;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading avatar: {ex.Message}");
                avatar.Image = null;
                avatar.BackColor = Color.LightGray;
            }
        }

        public void HighlightCurrentPlayer()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Padding = new Padding(3);
        }
    }
}