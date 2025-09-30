using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void LogInLabel_MouseEnter(object sender, EventArgs e)
        {
            LogInLabel.ForeColor = Color.Green;
            LogInLabel.Cursor = Cursors.Hand;
        }

        private void LogInLabel_MouseLeave(object sender, EventArgs e)
        {
            LogInLabel.ForeColor = Color.Black;
        }
    }
}
