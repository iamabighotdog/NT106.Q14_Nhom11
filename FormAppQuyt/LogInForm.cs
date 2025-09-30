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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {

        }

        private void ForgotPassword_MouseEnter(object sender, EventArgs e)
        {
            ForgotPassword.ForeColor = Color.Green;
            ForgotPassword.Cursor = Cursors.Hand;
        }

        private void ForgotPassword_MouseLeave(object sender, EventArgs e)
        {
            ForgotPassword.ForeColor = Color.Black;
        }

        private void SignUpLabel_MouseEnter(object sender, EventArgs e)
        {
            SignUpLabel.ForeColor = Color.Green;
            SignUpLabel.Cursor = Cursors.Hand;
        }

        private void SignUpLabel_MouseLeave(object sender, EventArgs e)
        {
            SignUpLabel.ForeColor = Color.Black;
        }
    }
}
