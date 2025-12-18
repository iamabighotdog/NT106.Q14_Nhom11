using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class Main : Form
    {
        private readonly string userInput;
        private byte[] selectedImage = null;
        private string avatarBase64 = null;
        public Main(string input)
        {
            InitializeComponent();
            userInput = input?.Trim() ?? string.Empty;
        }
        private class ProfileReply
        {
            public bool ok { get; set; }
            public string message { get; set; }
            public string fullname { get; set; }
            public string dob { get; set; }
            public string username { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string avatar { get; set; }
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
                tcpClient client = new tcpClient();
                string response = client.SendProfileData(userInput);

                var reply = JsonSerializer.Deserialize<ProfileReply>(response);

                if (reply != null && reply.ok)
                {
                    fullNamebox.Text = reply.fullname ?? "";
                    username.Text = reply.username ?? "";
                    emailBox.Text = reply.email ?? "";
                    phoneNumber.Text = reply.phone ?? "";
                    if (!string.IsNullOrEmpty(reply.dob))
                    {
                        if (DateTime.TryParse(reply.dob, out var d))
                            birthDate.Text = d.ToString("dd-MM-yyyy");
                    }
                    if (!string.IsNullOrEmpty(reply.avatar))
                    {
                        byte[] bytes = Convert.FromBase64String(reply.avatar);
                        using (var ms = new MemoryStream(bytes))
                        {
                            pic_Avatar.Image = Image.FromStream(ms);
                        }
                    }
                }
                else
                    MessageBox.Show(reply?.message ?? "Không thể tải profile!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void logOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (LogInForm login = new LogInForm())
            {
                login.StartPosition = FormStartPosition.CenterScreen;
                login.ShowDialog();
            }
            this.Close();
        }

        private void createQuiz_Click(object sender, EventArgs e)
        {
            createQuiz createQuiz = new createQuiz();
            createQuiz.ShowDialog();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    FileInfo fileInfo = new FileInfo(filePath);

                    const int MAX_FILE_SIZE_BYTES = 500 * 1024;

                    if (fileInfo.Length > MAX_FILE_SIZE_BYTES)
                    {
                        MessageBox.Show("Kích thước file ảnh quá lớn (> 500KB). Vui lòng chọn ảnh nhỏ hơn.",
                                        "Cảnh báo Kích thước", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        selectedImage = null;
                        return;
                    }

                    try
                    {

                        selectedImage = File.ReadAllBytes(filePath);

                        using (MemoryStream ms = new MemoryStream(selectedImage))
                        {
                            pic_Avatar.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi đọc file: " + ex.Message, "Lỗi");
                    }
                }
            }
        }
        private void myQuiz_Click(object sender, EventArgs e)
        {
            var f = new myQuiz(Global.UserId);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void changeInfo_Click(object sender, EventArgs e)
        {
            string fullname = fullNamebox.Text.Trim();
            string email = emailBox.Text.Trim();
            string phone = phoneNumber.Text.Trim();
            string dobRaw = birthDate.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Email không được để trống.");
                return;
            }
            if (!email.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }

            if (!string.IsNullOrEmpty(phone) && phone.Length < 9)
            {
                MessageBox.Show("Số điện thoại không hợp lệ!");
                return;
            }

            DateTime dob;
            if (!DateTime.TryParseExact(dobRaw, "dd-MM-yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out dob))
            {
                MessageBox.Show("Ngày sinh phải theo định dạng dd-MM-yyyy!");
                return;
            }
            string dobSend = dob.ToString("yyyy-MM-dd");
            try
            {
                tcpClient client = new tcpClient();
                string resp = client.SendUpdateProfile(
                    Global.UserId,
                    fullname,
                    email,
                    phone,
                    dobSend
                );

                var data = JsonSerializer.Deserialize<HomeResponse>(resp);

                if (data != null && data.ok)
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show(data?.message ?? "Cập nhật thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void changeavatar_Click(object sender, EventArgs e)
        {
            if (selectedImage == null)
            {
                MessageBox.Show("Không có avatar mới!");
                return;
            }

            string avatarBase64 = Convert.ToBase64String(selectedImage);

            try
            {
                tcpClient client = new tcpClient();
                string resp = client.SendUpdateAvatar(Global.UserId, avatarBase64);
                var res = JsonSerializer.Deserialize<HomeResponse>(resp);

                if (res.ok)
                {
                    MessageBox.Show("Avatar đã cập nhật!");
                    selectedImage = null;
                }
                else
                {
                    MessageBox.Show(res.message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void createRoom_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient client = new tcpClient();
                string response = client.SendGetMyQuiz(Global.UserId);

                var result = JsonSerializer.Deserialize<QuizCheckResponse>(response);

                if (result != null && result.ok && result.data != null)
                {
                    if (result.data.Count == 0)
                    {
                        MessageBox.Show("Bạn chưa có bộ câu hỏi nào. Vui lòng tạo bộ câu hỏi trước!",
                                      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    host hostForm = new host();
                    hostForm.StartPosition = FormStartPosition.CenterScreen;
                    hostForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không thể kiểm tra bộ câu hỏi. Vui lòng thử lại!",
                                  "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void play_Click(object sender, EventArgs e)
        {
            players enterForm = new players();
            enterForm.StartPosition = FormStartPosition.CenterScreen;
            enterForm.Show();
            this.Hide();
        }
        public class HomeResponse
        {
            public bool ok { get; set; }
            public string message { get; set; }
        }

        public class QuizCheckResponse
        {
            public bool ok { get; set; }
            public string message { get; set; }
            public List<QuizItemData> data { get; set; }
        }

        public class QuizItemData
        {
            public int id { get; set; }
            public string name { get; set; }
            public int total { get; set; }
            public string date { get; set; }
        }

        private void leaderboard_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Global.LastPlayedRoomId))
            {
                MessageBox.Show("Bạn chưa chơi phòng nào!\nHãy tham gia một trận chơi trước.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Mở leaderboard của phòng vừa chơi
            leaderboard leaderboardForm = new leaderboard(Global.LastPlayedRoomId);
            leaderboardForm.ShowDialog();
        }
    }
}