using System;
using System.Windows.Forms;

namespace test
{
    public partial class RegisterForm : Form
    {
        private readonly UserRepository repo;
        public RegisterForm()
        {
            InitializeComponent();
            repo = new UserRepository();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string pwd = txtPassword.Text;
                string confirm = txtConfirm.Text;
                bool agreed = chkAgree.Checked;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pwd))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!ValidationHelper.IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ.");
                    return;
                }
                if (!string.IsNullOrEmpty(phone) && !ValidationHelper.IsValidPhone(phone))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ (10 chữ số).");
                    return;
                }
                if (!ValidationHelper.IsStrongPassword(pwd))
                {
                    MessageBox.Show("Mật khẩu yếu. Phải ≥8 ký tự, có chữ hoa và ký tự đặc biệt.");
                    return;
                }
                if (pwd != confirm)
                {
                    MessageBox.Show("Xác nhận mật khẩu không khớp.");
                    return;
                }
                if (!agreed)
                {
                    MessageBox.Show("Bạn phải đồng ý điều khoản sử dụng.");
                    return;
                }

                if (repo.UsernameExists(username))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại.");
                    return;
                }
                if (repo.EmailExists(email))
                {
                    MessageBox.Show("Email đã được đăng ký.");
                    return;
                }

                string hashed = CryptoHelper.ComputeSha256Hash(pwd);
                repo.CreateUser(username, email, string.IsNullOrEmpty(phone) ? null : phone, hashed);

                MessageBox.Show("Đăng ký thành công. Vui lòng đăng nhập.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
