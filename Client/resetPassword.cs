using System;
using System.Text.Json;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class resetPassword : Form
    {
        private readonly string _resetToken;

        private class ApiReply
        {
            public bool ok { get; set; }
            public string message { get; set; }
        }

        public resetPassword(string resetToken)
        {
            InitializeComponent();
            _resetToken = resetToken;

            submit.Click += submit_Click;

            // nếu muốn ẩn mật khẩu:
            guna2TextBox1.PasswordChar = '•';
            guna2TextBox2.PasswordChar = '•';
        }

        private void submit_Click(object sender, EventArgs e)
        {
            string pw1 = guna2TextBox1.Text ?? "";
            string pw2 = guna2TextBox2.Text ?? "";

            if (string.IsNullOrWhiteSpace(pw1) || string.IsNullOrWhiteSpace(pw2))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu.");
                return;
            }

            if (pw1 != pw2)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }

            try
            {
                // bạn đang dùng SHA256 khi login :contentReference[oaicite:9]{index=9}
                string hashed = CryptoHelper.ComputeSha256Hash(pw1);

                tcpClient cli = new tcpClient();
                string resp = cli.SendResetPassword(_resetToken, hashed);
                var r = JsonSerializer.Deserialize<ApiReply>(resp);

                if (r != null && r.ok)
                {
                    MessageBox.Show(r.message ?? "Đổi mật khẩu thành công");
                    var login = new LogInForm();
                    login.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(r?.message ?? "Đổi mật khẩu thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
