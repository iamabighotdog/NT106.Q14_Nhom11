using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Configuration;


namespace FormAppQuyt
{
    public partial class SignUpForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["UserAuthDB"].ConnectionString;
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
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            string email = EmailBox.Text;
            string username = UsernameBox.Text;
            string phone = PhoneBox.Text;
            string password = PasswordBox.Text;
            string confirmPassword = ConfirmPassword.Text;
            string hashedPassword = CryptoHelper.ComputeSha256Hash(password);
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email");
                return;
            }
            else
            {
                if (!ValidationHelper.IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ");
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
                return;
            }
            else
            {
                if (!ValidationHelper.IsValidPhone(phone))
                {
                    MessageBox.Show("Số điện thoại phải gồm 10 chữ số");
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống.");
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
            if (!CheckAgreeTerms.Checked)
            {
                MessageBox.Show("Vui lòng đồng ý điều khoản sử dụng.");
                return;
            }
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ Email và Số điện thoại.");
                        return;
                    }
                    string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(checkUserQuery, connection))
                    {
                        cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                        int exists = (int)cmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            MessageBox.Show("Tên người dùng đã tồn tại.");
                            return;
                        }
                    }
                    string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(checkEmailQuery, connection))
                    {
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                        int exists = (int)cmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            MessageBox.Show("Email đã tồn tại.");
                            return;
                        }
                    }
                    string checkPhoneQuery = "SELECT COUNT(*) FROM Users WHERE Phone = @Phone";
                    using (SqlCommand cmd = new SqlCommand(checkPhoneQuery, connection))
                    {
                        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = phone;
                        int exists = (int)cmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            MessageBox.Show("Số điện thoại đã tồn tại.");
                            return;
                        }
                    }

                    string insertQuery = @"INSERT INTO Users (Username, Password, Email, Phone) 
                               VALUES (@Username, @Password, @Email, @Phone)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 255).Value = hashedPassword;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = phone;
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đăng ký thành công,vui lòng đăng nhập");
                LogInForm loginForm = new LogInForm();
                loginForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau: " + ex.Message);
            }


        }

    }
}
