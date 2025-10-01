using System;
using System.Windows.Forms;

namespace test
{
    public partial class MainForm : Form
    {
        private User _user;
        public MainForm(User user)
        {
            InitializeComponent();
            _user = user;
            lblWelcome.Text = $"Xin chào {_user.Username}";
        }
    }
}
