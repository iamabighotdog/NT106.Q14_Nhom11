using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace FormAppQuyt
{
    public partial class RankPopup : UserControl
    {

        public RankPopup()
        {
            InitializeComponent();
            this.Visible = false;
        }
        private int _lastRank = 0;

        public async Task ShowRankEffect(List<NeighborInfo> neighbors, int rankDiff = 0)
        {
            this.Invoke((MethodInvoker)delegate {
                this.Visible = true;
                this.BringToFront();
                HideAllRows();

                int cardHeight = 60;
                int spacing = 10;
                int startX = 20;

                int actualListHeight = (neighbors.Count * cardHeight) + ((neighbors.Count - 1) * spacing);
                int startY = (this.Height - actualListHeight) / 2;

                for (int i = 0; i < neighbors.Count; i++)
                {
                    var info = neighbors[i];
                    var pic = GetPictureBox(i);
                    var lbl = GetLabel(i);

                    if (pic != null && lbl != null)
                    {
                        string trendIcon = "";
                        if (info.isMe && rankDiff != 0)
                        {
                            trendIcon = (rankDiff > 0) ? $" ▲{rankDiff}" : $" ▼{Math.Abs(rankDiff)}";
                            lbl.ForeColor = (rankDiff > 0) ? Color.Lime : Color.Red;
                        }
                        else
                        {
                            lbl.ForeColor = info.isMe ? Color.Gold : Color.White;
                        }

                        lbl.Text = $"{info.rank}. {info.name} ({info.score} pt){trendIcon}";

                        SetAvatar(pic, info.avatar);
                        pic.Size = new Size(50, 50);
                        pic.Left = startX;
                        pic.Top = startY + i * (cardHeight + spacing);
                        lbl.Left = pic.Right + 15;
                        lbl.Top = pic.Top + (pic.Height / 2) - (lbl.Height / 2);
                        pic.Visible = true;
                        lbl.Visible = true;
                        AnimateRow(pic, lbl);
                    }
                }
            });

            await Task.Delay(3000);
            this.Invoke((MethodInvoker)delegate { this.Visible = false; });
        }
        private void AnimateRow(Control pic, Control lbl)
        {
            int finalPicX = pic.Left;
            int finalLblX = lbl.Left;

            pic.Left = finalPicX - 30;
            lbl.Left = finalLblX - 30;
            pic.Enabled = false; 

            Timer t = new Timer();
            t.Interval = 10;
            t.Tick += (s, e) =>
            {
                if (pic.Left < finalPicX)
                {
                    pic.Left += 3;
                    lbl.Left += 3;
                }
                else
                {
                    pic.Left = finalPicX;
                    lbl.Left = finalLblX;
                    t.Stop();
                    t.Dispose();
                }
            };
            t.Start();
        }
        private Guna2CirclePictureBox GetPictureBox(int index)
        {
            switch (index)
            {
                case 0: return guna2CirclePictureBox1;
                case 1: return guna2CirclePictureBox3;
                case 2: return guna2CirclePictureBox4;
                case 3: return guna2CirclePictureBox5;
                case 4: return guna2CirclePictureBox6;
                default: return null;
            }
        }

        private Guna2HtmlLabel GetLabel(int index)
        {
            switch (index)
            {
                case 0: return lbl1;
                case 1: return lbl2;
                case 2: return lbl3;
                case 3: return lb4;
                case 4: return lb5;
                default: return null;
            }
        }

        private void AnimateClimb(Control pic, Control lbl, int targetY)
        {
            pic.Visible = true;
            lbl.Visible = true;

            int startY = targetY + 30;
            pic.Top = startY;
            lbl.Top = startY + (pic.Height / 2) - (lbl.Height / 2);

            Timer t = new Timer();
            t.Interval = 15; 
            t.Tick += (s, e) =>
            {
                if (Math.Abs(pic.Top - targetY) > 2)
                {
                    int step = (pic.Top > targetY) ? -4 : 4;
                    pic.Top += step;
                    lbl.Top += step;
                }
                else
                {
                    pic.Top = targetY;
                    lbl.Top = targetY + (pic.Height / 2) - (lbl.Height / 2);
                    t.Stop();
                    t.Dispose();
                }
            };
            t.Start();
        }

        private void HideAllRows()
        {
            guna2CirclePictureBox1.Visible = guna2CirclePictureBox3.Visible =
            guna2CirclePictureBox4.Visible = guna2CirclePictureBox5.Visible =
            guna2CirclePictureBox6.Visible = false;

            lbl1.Visible = lbl2.Visible = lbl3.Visible = lb4.Visible = lb5.Visible = false;
        }

        private void SetAvatar(Guna2CirclePictureBox pic, string base64)
        {
            if (string.IsNullOrEmpty(base64)) return;
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    pic.Image = Image.FromStream(ms);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch { }
        }
    }
    public class NeighborInfo
    {
        public int rank { get; set; }
        public string name { get; set; }
        public int score { get; set; }
        public string avatar { get; set; }
        public bool isMe { get; set; }
    }
   
}