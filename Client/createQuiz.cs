using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class createQuiz : Form
    {
        private List<QuizQuestion> _questions = new List<QuizQuestion>();
        private int currentIndex = 0;
        private string _imageBase64 = null;
        private int _maxQuestions = 10;
        public createQuiz()
        {
            InitializeComponent();
            _questions.Add(new QuizQuestion()); 
            LoadQuestionToUI();
            UpdateQuestionNumber();

            questionCountBox.TextChanged += QuestionCountBox_TextChanged;
        }
        private void ClearInputs()
        {
            quesBox.Text = "";
            correctBox.Text = "";
            wrongBox1.Text = "";
            wrongBox2.Text = "";
            wrongBox3.Text = "";
            pic.Image = null;
            _imageBase64 = null;
        }
        private void UpdateQuestionNumber()
        {
            num.Text = $"{currentIndex + 1}/{_maxQuestions}";
        }
        private Image Base64ToImage(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);
            using (MemoryStream ms = new MemoryStream(bytes))
                return Image.FromStream(ms);
        }
        private void SaveCurrentInputToList()
        {
            var q = new QuizQuestion()
            {
                NoiDung = quesBox.Text.Trim(),
                DapAnDung = correctBox.Text.Trim(),
                Sai1 = wrongBox1.Text.Trim(),
                Sai2 = wrongBox2.Text.Trim(),
                Sai3 = wrongBox3.Text.Trim(),
                ImageBase64 = _imageBase64
            };

            if (currentIndex >= _questions.Count)
                _questions.Add(q);
            else
                _questions[currentIndex] = q;
        }
        private void LoadQuestionToUI()
        {
            if (currentIndex >= _questions.Count)
            {
                ClearInputs();
                return;
            }

            var q = _questions[currentIndex];

            quesBox.Text = q.NoiDung ?? "";
            correctBox.Text = q.DapAnDung ?? "";
            wrongBox1.Text = q.Sai1 ?? "";
            wrongBox2.Text = q.Sai2 ?? "";
            wrongBox3.Text = q.Sai3 ?? "";

            _imageBase64 = q.ImageBase64; 

            if (string.IsNullOrEmpty(q.ImageBase64))
            {
                pic.Image = Properties.Resources.istockphoto_1386740242_612x612;  
            }
            else
            {
                pic.Image = Base64ToImage(q.ImageBase64);
            }
        }
        private void next_Click(object sender, EventArgs e)
        {
            if (currentIndex + 1 >= _maxQuestions)
            {
                MessageBox.Show($"Đã đạt giới hạn {_maxQuestions} câu hỏi!");
                return;
            }

            if (!ValidateCurrentQuestion())
            {
                return;
            }

            SaveCurrentInputToList();

            
            currentIndex++;

            if (currentIndex >= _questions.Count)
            {
                _questions.Add(new QuizQuestion());
            }

            LoadQuestionToUI();
            UpdateQuestionNumber();
        }
        private void previous_Click(object sender, EventArgs e)
        {
            SaveCurrentInputToList();

            if (currentIndex > 0)
            {
                SaveCurrentInputToList();
                currentIndex--;
                LoadQuestionToUI();
                UpdateQuestionNumber();
            }
            else
            {
                MessageBox.Show("Đây là câu hỏi đầu tiên!");
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
                        MessageBox.Show("Ảnh quá lớn! < 200KB");
                        return;
                    }

                    _imageBase64 = Convert.ToBase64String(bytes);
                    pic.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (_questions.Count >= _maxQuestions)
            {
                MessageBox.Show($"Đã đạt giới hạn {_maxQuestions} câu hỏi!");
                return;
            }

            if (!ValidateCurrentQuestion())
            {
                return;
            }

            SaveCurrentInputToList();

            _questions.Add(new QuizQuestion());
            currentIndex = _questions.Count - 1;

            ClearInputs();
            UpdateQuestionNumber();

            MessageBox.Show("Đã thêm câu hỏi mới!");
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(quizBox.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bộ câu hỏi!");
                quizBox.Focus();
                return;
            }

            bool currentQuestionIsEmpty = string.IsNullOrWhiteSpace(quesBox.Text) &&
                                   string.IsNullOrWhiteSpace(correctBox.Text) &&
                                   string.IsNullOrWhiteSpace(wrongBox1.Text) &&
                                   string.IsNullOrWhiteSpace(wrongBox2.Text) &&
                                   string.IsNullOrWhiteSpace(wrongBox3.Text);

            if (!currentQuestionIsEmpty)
            {
                // Nếu câu hiện tại có dữ liệu thì phải validate
                if (!ValidateCurrentQuestion())
                {
                    return;
                }

                // Kiểm tra xem có vượt quá giới hạn không (trường hợp người dùng đã nhập câu thứ 3 khi giới hạn là 2)
                if (currentIndex >= _maxQuestions)
                {
                    MessageBox.Show($"Câu hỏi hiện tại vượt quá giới hạn {_maxQuestions} câu!\nVui lòng xóa câu này hoặc tăng giới hạn.");
                    return;
                }

                SaveCurrentInputToList();
            }

            // Lọc bỏ các câu rỗng
            var validQuestions = _questions.Where(q =>
                !string.IsNullOrWhiteSpace(q.NoiDung) &&
                !string.IsNullOrWhiteSpace(q.DapAnDung) &&
                !string.IsNullOrWhiteSpace(q.Sai1) &&
                !string.IsNullOrWhiteSpace(q.Sai2) &&
                !string.IsNullOrWhiteSpace(q.Sai3)
            ).ToList();

            // Kiểm tra số câu hỏi hợp lệ
            if (validQuestions.Count == 0)
            {
                MessageBox.Show("Chưa có câu hỏi hợp lệ nào!");
                return;
            }

            // Kiểm tra có vượt giới hạn không
            if (validQuestions.Count > _maxQuestions)
            {
                MessageBox.Show($"Số câu hỏi ({validQuestions.Count}) vượt quá giới hạn ({_maxQuestions})!");
                return;
            }

            // Kiểm tra đã đủ số câu chưa
            if (validQuestions.Count < _maxQuestions)
            {
                var result = MessageBox.Show(
                    $"Bạn mới tạo {validQuestions.Count}/{_maxQuestions} câu. Bạn có muốn lưu không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            var pkg = new QuizPackage
            {
                action = "create_exam",
                UserId = Global.UserId,
                TenBo = quizBox.Text.Trim(),
                Questions = validQuestions // Chỉ lưu câu hợp lệ
            };

            string json = JsonSerializer.Serialize(pkg);

            try
            {
                using (TcpClient client = new TcpClient())
                {
                    client.Connect("127.0.0.1", 3636);
                    using (var stream = client.GetStream())
                    {
                        byte[] buf = Encoding.UTF8.GetBytes(json + "\n");
                        stream.Write(buf, 0, buf.Length);
                    }
                }

                MessageBox.Show($"Đã lưu {validQuestions.Count} câu hỏi thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}");
            }
        }

        private void QuestionCountBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(questionCountBox.Text, out int count))
            {
                if (count > 0 && count <= 100) // Giới hạn tối đa 100 câu
                {
                    _maxQuestions = count;
                    UpdateQuestionNumber();
                }
                else
                {
                    MessageBox.Show("Số câu hỏi phải từ 1 đến 100!");
                    questionCountBox.Text = _maxQuestions.ToString();
                }
            }
        }

        private bool ValidateCurrentQuestion()
        {
            if (string.IsNullOrWhiteSpace(quesBox.Text))
            {
                MessageBox.Show("Vui lòng nhập câu hỏi!");
                quesBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(correctBox.Text))
            {
                MessageBox.Show("Vui lòng nhập câu trả lời đúng!");
                correctBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(wrongBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập câu trả lời sai thứ 1!");
                wrongBox1.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(wrongBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập câu trả lời sai thứ 2!");
                wrongBox2.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(wrongBox3.Text))
            {
                MessageBox.Show("Vui lòng nhập câu trả lời sai thứ 3!");
                wrongBox3.Focus();
                return false;
            }

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
