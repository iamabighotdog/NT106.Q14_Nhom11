using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class createQuiz : Form
    {
        private int currentIndex = 0;
        private int _maxQuestions = 10;
        private List<QuizQuestion> _questions;
        private string _imageBase64 = null;

        public createQuiz()
        {
            InitializeComponent();
            _questions = Enumerable.Range(0, _maxQuestions)
                .Select(x => new QuizQuestion())
                .ToList();

            LoadQuestionUI();
            UpdatePage();
            questionCountBox.TextChanged += QuestionCountBox_TextChanged;
        }

        private void LoadQuestionUI()
        {
            var q = _questions[currentIndex];

            quesBox.Text = q.NoiDung ?? "";
            correctBox.Text = q.DapAnDung ?? "";
            wrongBox1.Text = q.Sai1 ?? "";
            wrongBox2.Text = q.Sai2 ?? "";
            wrongBox3.Text = q.Sai3 ?? "";

            _imageBase64 = q.ImageBase64;

            if (!string.IsNullOrEmpty(q.ImageBase64))
                pic.Image = Base64ToImage(q.ImageBase64);
            else
                pic.Image = null;
        }

        private void SaveCurrent()
        {
            var q = _questions[currentIndex];
            q.NoiDung = quesBox.Text.Trim();
            q.DapAnDung = correctBox.Text.Trim();
            q.Sai1 = wrongBox1.Text.Trim();
            q.Sai2 = wrongBox2.Text.Trim();
            q.Sai3 = wrongBox3.Text.Trim();
            q.ImageBase64 = _imageBase64;
        }

        private void UpdatePage()
        {
            num.Text = $"{currentIndex + 1}/{_maxQuestions}";
        }

        private Image Base64ToImage(string b64)
        {
            byte[] bytes = Convert.FromBase64String(b64);
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }


        private void next_Click(object sender, EventArgs e)
        {
            SaveCurrent();
            if (currentIndex < _maxQuestions - 1)
            {
                currentIndex++;
                LoadQuestionUI();
                UpdatePage();
            }
        }

        private void previous_Click(object sender, EventArgs e)
        {
            SaveCurrent();
            if (currentIndex > 0)
            {
                currentIndex--;
                LoadQuestionUI();
                UpdatePage();
            }
        }

        private void addPic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh .jpg|*.jpg;*.jpeg|Ảnh .png|*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    byte[] bytes = File.ReadAllBytes(ofd.FileName);

                    if (bytes.Length > 200 * 1024)
                    {
                        MessageBox.Show("Ảnh quá lớn! <200KB");
                        return;
                    }

                    _imageBase64 = Convert.ToBase64String(bytes);
                    pic.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (!ValidateCurrent())
            {
                MessageBox.Show("Câu hỏi chưa hợp lệ!");
                return;
            }

            SaveCurrent();
            MessageBox.Show($"Đã lưu câu hỏi #{currentIndex + 1}");
        }

        private void save_Click(object sender, EventArgs e)
        {
            SaveCurrent();

            if (string.IsNullOrWhiteSpace(quizBox.Text))
            {
                MessageBox.Show("Nhập tên bộ câu hỏi");
                return;
            }

            var valid = _questions
                .Where(q => ValidateObject(q))
                .ToList();

            if (valid.Count == 0)
            {
                MessageBox.Show("Không có câu hỏi hợp lệ");
                return;
            }

            var pkg = new QuizPackage
            {
                action = "create_exam",
                UserId = Global.UserId,
                TenBo = quizBox.Text.Trim(),
                Questions = valid
            };

            string json = JsonSerializer.Serialize(pkg);

            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 3636))
                {
                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] buf = Encoding.UTF8.GetBytes(json + "\n");
                        stream.Write(buf, 0, buf.Length);
                    }
                }

                MessageBox.Show("Đã lưu bộ câu hỏi!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }

        }

        private void QuestionCountBox_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(questionCountBox.Text, out int newCount)) return;
            if (newCount < 1 || newCount > 100)
            {
                MessageBox.Show("Số câu từ 1 đến 100");
                questionCountBox.Text = _maxQuestions.ToString();
                return;
            }

            _maxQuestions = newCount;

            // Resize list
            _questions = _questions.Take(newCount).ToList();
            while (_questions.Count < newCount)
                _questions.Add(new QuizQuestion());

            if (currentIndex >= newCount)
                currentIndex = newCount - 1;

            UpdatePage();
            LoadQuestionUI();
        }

        private bool ValidateObject(QuizQuestion q)
        {
            return !string.IsNullOrWhiteSpace(q.NoiDung)
                && !string.IsNullOrWhiteSpace(q.DapAnDung)
                && !string.IsNullOrWhiteSpace(q.Sai1)
                && !string.IsNullOrWhiteSpace(q.Sai2)
                && !string.IsNullOrWhiteSpace(q.Sai3);
        }

        private bool ValidateCurrent()
        {
            if (string.IsNullOrWhiteSpace(quesBox.Text)) return false;
            if (string.IsNullOrWhiteSpace(correctBox.Text)) return false;
            if (string.IsNullOrWhiteSpace(wrongBox1.Text)) return false;
            if (string.IsNullOrWhiteSpace(wrongBox2.Text)) return false;
            if (string.IsNullOrWhiteSpace(wrongBox3.Text)) return false;
            return true;
        }
    }

    public class QuizQuestion
    {
        public string NoiDung { get; set; }
        public string DapAnDung { get; set; }
        public string Sai1 { get; set; }
        public string Sai2 { get; set; }
        public string Sai3 { get; set; }
        public string ImageBase64 { get; set; }
    }

    public class QuizPackage
    {
        public string action { get; set; }
        public int UserId { get; set; }
        public string TenBo { get; set; }
        public List<QuizQuestion> Questions { get; set; }
    }
}
