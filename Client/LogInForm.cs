using System;
using System.Collections;
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
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;



namespace FormAppQuyt
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            InitializeComponent();
            ToSignUp.MouseEnter += ToSignUp_MouseEnter;
            ToSignUp.MouseLeave += ToSignUp_MouseLeave;
            ToSignUp.HoverState.FillColor = ToSignUp.FillColor;
            ToSignUp.PressedColor = ToSignUp.FillColor;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ToSignUp_MouseEnter(object sender, EventArgs e)
        {
            ToSignUp.ForeColor = Color.Green;
            ToSignUp.Cursor = Cursors.Hand;
        }

        private void ToSignUp_MouseLeave(object sender, EventArgs e)
        {
            ToSignUp.ForeColor = Color.Black;
        }

        private void ToSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            this.Hide();
            signUpForm.Show();
        }
        private class LoginReply
        {
            public bool ok { get; set; }
            public string message { get; set; }
        }
        private void LogInButton_Click(object sender, EventArgs e)
        {
            string identifier = EmailBox.Text?.Trim();
            string password = PasswordBox.Text ?? "";
            if (string.IsNullOrEmpty(identifier) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            string hashed = CryptoHelper.ComputeSha256Hash(password);
            try
            {
                tcpClient client = new tcpClient();
                string resp = client.SendLoginData(identifier, hashed);
                try
                {
                    LoginReply r = JsonSerializer.Deserialize<LoginReply>(resp);
                    if (r != null)
                    {
                        if (r.ok)
                        {
                            MessageBox.Show(r.message ?? "Đăng nhập thành công");
                            Main mainForm = new Main(identifier);
                            mainForm.Show();
                            this.Hide();
                            return;
                        }
                        else
                        {
                            MessageBox.Show(r.message ?? "Tài khoản hoặc mật khẩu không chính xác");
                            return;
                        }
                    }
                }
                catch { }
                if (resp.StartsWith("ERROR:"))
                {
                    MessageBox.Show(resp);
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi kết nối máy chủ: " + ex.Message);
            }
        }

    }
}