using System;
using System.Text.Json;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class Main : Form
    {
        private readonly string userInput;

        public Main(string input)
        {
            InitializeComponent();
            userInput = input?.Trim() ?? string.Empty;
        }
        private class ProfileReply
        {
            public bool ok { get; set; }
            public string message { get; set; }
            public string username { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Không có thông tin người dùng để tra cứu.");
                return;
            }

            try
            {
                var client = new tcpClient();
                string response = client.SendProfileData(userInput);
                ProfileReply reply = JsonSerializer.Deserialize<ProfileReply>(response);
                if (reply != null && reply.ok)
                {
                    username.Text = reply.username ?? "";
                    email.Text = reply.email ?? "";
                    phoneNumber.Text = reply.phone ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}