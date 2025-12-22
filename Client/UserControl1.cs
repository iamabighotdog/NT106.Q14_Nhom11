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
                lbl1.Text = $"+{gainedScore} điểm";
                lbl1.ForeColor = Color.Green;
            }
            else
            {
                lbl1.Text = "+0 điểm (Sai)";
                lbl1.ForeColor = Color.Red;
            }

            if (_currentRank == 0 || _currentRank == newRank)
            {
                lbl2.Text = "#" + newRank;
                lbl3.Text = "HẠNG CỦA BẠN";
                lbl3.ForeColor = Color.Gray;
                lbl2.ForeColor = Color.Black;
            }
            else
            {
                int start = _currentRank;
                int end = newRank;
                int step = (start < end) ? 1 : -1;

                if (newRank < _currentRank) 
                {
                    lbl3.Text = "▲";
                    lbl3.ForeColor = Color.Orange;
                    lbl2.ForeColor = Color.Gold;
                }
                else 
                {
                    lbl3.Text = "▼";
                    lbl3.ForeColor = Color.Gray;
                    lbl2.ForeColor = Color.Gray;
                }

                int temp = start;
                while (temp != end)
                {
                    lbl2.Text = "#" + temp;
                    await Task.Delay(150); 
                    temp += step;
                }
                lbl2.Text = "#" + end;
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