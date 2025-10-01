using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class LogInForm : Form
    {
        string connectionString = "Data Source=LAPTOP-BQLCJQLQ;Initial Catalog=UserManagement;Integrated Security=True;TrustServerCertificate=True";
        public LogInForm()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            InitializeComponent();
            ToSignUp.MouseEnter += ToSignUp_MouseEnter; 
            ToSignUp.MouseLeave += ToSignUp_MouseLeave; 
            ToSignUp.Click += ToSignUp_Click; 
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
            signUpForm.Show();
            this.Hide();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            
            string EmailOrPhone = EmailBox.Text;
            string Password = PasswordBox.Text;
            string hashedPassword = CryptoHelper.ComputeSha256Hash(Password);
            if (EmailOrPhone == "" || Password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            string Query = "SELECT COUNT(*) FROM Users WHERE (Email='" + EmailOrPhone + "' OR Username='" + EmailOrPhone + "' OR Phone='" + EmailOrPhone + "') AND Password='" + hashedPassword + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(Query, connection))
                    {
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Đăng nhập thành công");
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

       
    }
}
