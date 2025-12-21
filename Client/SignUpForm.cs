using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace FormAppQuyt
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            InitializeComponent();
            ToLogIn.MouseEnter += ToLogIn_MouseEnter;
            ToLogIn.MouseLeave += ToLogIn_MouseLeave;
            ToLogIn.Click += ToLogIn_Click;
            ToLogIn.HoverState.FillColor = ToLogIn.FillColor;
            ToLogIn.PressedColor = ToLogIn.FillColor;
        }
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ToLogIn_MouseEnter(object sender, EventArgs e)
        {
            ToLogIn.ForeColor = Color.Green;
            ToLogIn.Cursor = Cursors.Hand;
        }

        private void ToLogIn_MouseLeave(object sender, EventArgs e)
        {
            ToLogIn.ForeColor = Color.Black;
        }
        private void ToLogIn_Click(object sender, EventArgs e)
        {
            LogInForm loginForm = new LogInForm();
            loginForm.Show(); 
            this.Close();
        }
        private class SimpleReply
        {
            public bool ok { get; set; }
            public string message { get; set; }
        }
   
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            string email = EmailBox.Text;
            string username = UsernameBox.Text;
            string phone = PhoneBox.Text;
            string password = PasswordBox.Text;
            string confirmPassword = ConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email");
                return;
            }

            if (!ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.");
                EmailBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
                return;
            }

            if (!ValidationHelper.IsValidPhone(phone))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập 10 chữ số.");
                PhoneBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống.");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.");
                PasswordBox.Focus();
                return;
            }

            if (!ValidationHelper.IsStrongPass(password))
            {
                MessageBox.Show("Mật khẩu phải từ 8 ký tự, gồm chữ hoa, thường, số và ký tự đặc biệt.");
                PasswordBox.Focus();
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }
            string hashedPassword = CryptoHelper.ComputeSha256Hash(password);
            if (!CheckAgreeTerms.Checked)
            {
                MessageBox.Show("Vui lòng đồng ý điều khoản sử dụng.");
                return;
            }

            try
            {
                tcpClient client = new tcpClient();
                string resp = client.SendRegisterData(username, email, phone, hashedPassword);
                SimpleReply r = null;
                try { r = JsonSerializer.Deserialize<SimpleReply>(resp); } catch { }

                if (r != null)
                {
                    if (r.ok)
                    {
                        MessageBox.Show(r.message ?? "Đăng ký thành công, vui lòng đăng nhập");
                        LogInForm loginForm = new LogInForm();
                        loginForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(r.message ?? "Đăng ký thất bại");
                    }
                    return;
                }
                MessageBox.Show("Đăng ký thất bại");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi kết nối máy chủ: " + ex.Message);
            }
        }

    }
}