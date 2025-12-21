using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class RankPopup : UserControl
    {
        private int _currentRank = 0;

        public RankPopup()
        {
            InitializeComponent();
            this.Visible = false;
        }

        public async Task ShowAnimation(int newRank, int gainedScore, bool correct)
        {
            this.Visible = true;
            this.BringToFront();

            if (correct)
            {
                lblScore.Text = $"+{gainedScore} điểm";
                lblScore.ForeColor = Color.Green;
            }
            else
            {
                lblScore.Text = "+0 điểm (Sai)";
                lblScore.ForeColor = Color.Red;
            }

            if (_currentRank == 0 || _currentRank == newRank)
            {
                lblRankValue.Text = "#" + newRank;
                lblRankTitle.Text = "HẠNG CỦA BẠN";
                lblRankTitle.ForeColor = Color.Gray;
                lblRankValue.ForeColor = Color.Black;
            }
            else
            {
                int start = _currentRank;
                int end = newRank;
                int step = (start < end) ? 1 : -1;

                if (newRank < _currentRank) 
                {
                    lblRankTitle.Text = "▲";
                    lblRankTitle.ForeColor = Color.Orange;
                    lblRankValue.ForeColor = Color.Gold;
                }
                else 
                {
                    lblRankTitle.Text = "▼";
                    lblRankTitle.ForeColor = Color.Gray;
                    lblRankValue.ForeColor = Color.Gray;
                }

                int temp = start;
                while (temp != end)
                {
                    lblRankValue.Text = "#" + temp;
                    await Task.Delay(150); 
                    temp += step;
                }
                lblRankValue.Text = "#" + end;
            }

            _currentRank = newRank;

            await Task.Delay(3000);
            this.Visible = false;
        }

        public void Reset()
        {
            _currentRank = 0;
            this.Visible = false;
        }
    }
}