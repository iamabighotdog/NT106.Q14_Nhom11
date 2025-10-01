using System;
using System.Windows.Forms;

namespace test
{
    public partial class LoginForm : Form
    {
        private readonly UserRepository repo;
        public LoginForm()
        {
            InitializeComponent();
            repo = new UserRepository();

            if (repo.TestConnection())
            {
                MessageBox.Show("Kết nối DB OK");
            }
            else
            {
                MessageBox.Show("Kết nối DB thất bại");
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string identifier = txtIdentifier.Text.Trim();
                string pwd = txtPassword.Text;

                if (string.IsNullOrEmpty(identifier) || string.IsNullOrEmpty(pwd))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var user = repo.GetUserByLogin(identifier);
                if (user == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại.");
                    return;
                }

                string hashed = CryptoHelper.ComputeSha256Hash(pwd);
                if (!string.Equals(hashed, user.PasswordHash, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mật khẩu không đúng.");
                    return;
                }

                // Nếu không cần xác minh email, có thể bỏ kiểm tra:
                // if (!user.IsEmailConfirmed) { MessageBox.Show("Chưa kích hoạt email."); return; }

                var main = new MainForm(user);
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var reg = new RegisterForm();
            reg.ShowDialog();
        }

       
    }
}
