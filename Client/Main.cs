using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;

namespace FormAppQuyt
{
    public partial class Main : Form
    {
        private readonly string userInput;
        private byte[] selectedImage = null;

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
                tcpClient client = new tcpClient();
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
    }
}