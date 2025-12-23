using System;
using System.Text.Json;
using System.Windows.Forms;
using FormAppQuyt.Networking;

namespace FormAppQuyt
{
    public partial class OtpForm : Form
    {
        private Timer _timer;
        private int _secondsLeft;

        public class ApiReply
        {
            public bool ok { get; set; }  // Chỉ ra xem hành động có thành công không
            public string message { get; set; }  // Thông điệp trả về
            public string resetToken { get; set; }  // Thông tin token khi xác nhận OTP thành công
        }

        public OtpForm()
        {
            InitializeComponent();

            sendOTP.Click += sendOTP_Click;
            check.Click += check_Click;

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _secondsLeft--;
            if (_secondsLeft <= 0)
            {
                _timer.Stop();
                sendOTP.Enabled = true;
                sendOTP.Text = "Gửi OTP về gmail";
                return;
            }

            sendOTP.Text = $"Gửi lại ({_secondsLeft}s)";
        }

        private async void sendOTP_Click(object sender, EventArgs e)
        {
            string emailValue = email.Text?.Trim();
            if (string.IsNullOrWhiteSpace(emailValue))
            {
                MessageBox.Show("Vui lòng nhập email!");
                return;
            }

            try
            {
                TcpRequestClient cli = new TcpRequestClient();
                string resp = cli.SendForgotPasswordSendOtp(emailValue); // Gửi OTP với email người dùng nhập
                var r = JsonSerializer.Deserialize<ApiReply>(resp);

                if (r != null && r.ok)
                {
                    MessageBox.Show(r.message ?? "Đã gửi OTP");

                    // Khoá nút gửi trong 60 giây (60s)
                    _secondsLeft = 60;
                    sendOTP.Enabled = false;
                    _timer.Start();
                }
                else
                {
                    MessageBox.Show(r?.message ?? "Gửi OTP thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private async void check_Click(object sender, EventArgs e)
        {
            string otpValue = guna2TextBox1.Text?.Trim();
            if (string.IsNullOrWhiteSpace(otpValue))
            {
                MessageBox.Show("Vui lòng nhập OTP.");
                return;
            }

            try
            {
                TcpRequestClient cli = new TcpRequestClient();
                string resp = cli.SendForgotPasswordVerifyOtp(email.Text.Trim(), otpValue); // Xác nhận OTP với email người dùng nhập
                var r = JsonSerializer.Deserialize<ApiReply>(resp);

                if (r != null && r.ok)
                {
                    MessageBox.Show(r.message ?? "OTP đúng");

                    // Mở form resetPassword và gửi resetToken
                    var f = new ResetPasswordForm(r.resetToken);
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(r?.message ?? "OTP không hợp lệ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new LogInForm();
            login.Show();
        }
    }

}
