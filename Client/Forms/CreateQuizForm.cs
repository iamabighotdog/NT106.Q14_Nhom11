using FormAppQuyt.Networking;
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
    public partial class CreateQuizForm : Form
    {
        private int currentIndex = 0;
        private int _maxQuestions = 10;
        private List<QuizQuestion> _questions;
        private string _imageBase64 = null;

        public CreateQuizForm()
        {
            InitializeComponent();

            if (timeBox != null)
            {
                timeBox.Items.AddRange(new object[] { "10", "15", "20", "30", "45", "60", "90", "120" });
                timeBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
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

            if (timeBox != null)
            {
                if (q.TimeLimit <= 0) q.TimeLimit = 20;
                timeBox.SelectedItem = q.TimeLimit.ToString();
            }
            _imageBase64 = q.ImageBase64;

            pic.Image?.Dispose();
            pic.Image = null;

            if (!string.IsNullOrWhiteSpace(_imageBase64))
            {
                pic.Image = Base64ToImage(_imageBase64);
            }
            else
            {
                _imageBase64 = DefaultQuestionImageBase64;
                pic.Image = Base64ToImage(_imageBase64);
            }

        }

        private void SaveCurrent()
        {
            var q = _questions[currentIndex];
            q.NoiDung = quesBox.Text.Trim();
            q.DapAnDung = correctBox.Text.Trim();
            q.Sai1 = wrongBox1.Text.Trim();
            q.Sai2 = wrongBox2.Text.Trim();
            q.Sai3 = wrongBox3.Text.Trim();
            q.ImageBase64 = string.IsNullOrWhiteSpace(_imageBase64)? DefaultQuestionImageBase64 : _imageBase64;

            if (timeBox != null && timeBox.SelectedItem != null)
            {
                if (int.TryParse(timeBox.SelectedItem.ToString(), out int t))
                    q.TimeLimit = t;
                else
                    q.TimeLimit = 20;
            }
            else
            {
                q.TimeLimit = 20;
            }
        }

        private void UpdatePage()
        {
            num.Text = $"{currentIndex + 1}/{_maxQuestions}";
        }

        private Image Base64ToImage(string b64)
        {
            byte[] bytes = Convert.FromBase64String(b64);
            using (var ms = new MemoryStream(bytes))
            using (var img = Image.FromStream(ms))
            {
                return new Bitmap(img);
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
                    Image img = null;
                    try
                    {
                        img = Image.FromFile(ofd.FileName);
                        pic.Image?.Dispose();
                        pic.Image = new Bitmap(img);
                    }
                    finally
                    {
                        if (img != null)
                        {
                            img.Dispose();
                        }
                    }
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

            try
            {
                TcpRequestClient client = new TcpRequestClient();
                string resp = client.SendCreateQuiz(
                    Global.UserId,
                    quizBox.Text.Trim(),
                    valid
                );

                var res = JsonSerializer.Deserialize<ClientResponse>(resp);

                if (res.ok)
                {
                    MessageBox.Show("Đã lưu bộ câu hỏi!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(res.message);
                }
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

        private static string ImageToBase64(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private string DefaultQuestionImageBase64 =>
            ImageToBase64(FormAppQuyt.Properties.Resources.istockphoto_1386740242_612x612);


        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImportTxt_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files (*.txt)|*.txt";
                ofd.Title = "Chọn file danh sách câu hỏi";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8)
                                             .Where(l => !string.IsNullOrWhiteSpace(l))
                                             .ToArray();

                        if (lines.Length == 0) return;

                        if (!int.TryParse(lines[0], out int numQuestions))
                        {
                            MessageBox.Show("Dòng đầu tiên phải là số lượng câu hỏi!");
                            return;
                        }

                        List<QuizQuestion> importedList = new List<QuizQuestion>();
                        int currentLine = 1; 

                        for (int i = 0; i < numQuestions; i++)
                        {
                            if (currentLine + 4 < lines.Length)
                            {
                                var q = new QuizQuestion
                                {
                                    NoiDung = lines[currentLine].Trim(),
                                    DapAnDung = lines[currentLine + 1].Trim(),
                                    Sai1 = lines[currentLine + 2].Trim(),
                                    Sai2 = lines[currentLine + 3].Trim(),
                                    Sai3 = lines[currentLine + 4].Trim(),
                                    TimeLimit = 20, 
                                    ImageBase64 = DefaultQuestionImageBase64 
                                };
                                importedList.Add(q);
                                currentLine += 5;
                            }
                        }

                        if (importedList.Count > 0)
                        {
                            _questions = importedList;
                            _maxQuestions = importedList.Count;
                            currentIndex = 0;

                            questionCountBox.Text = _maxQuestions.ToString();
                            LoadQuestionUI(); 
                            UpdatePage(); 

                            MessageBox.Show($"Đã nạp thành công {importedList.Count} câu hỏi!", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi đọc file: " + ex.Message);
                    }
                }
            }
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
        public int TimeLimit { get; set; } = 20;
    }

    public class QuizPackage
    {
        public string action { get; set; }
        public int UserId { get; set; }
        public string TenBo { get; set; }
        public List<QuizQuestion> Questions { get; set; }
    }
    public class ClientResponse
    {
        public bool ok { get; set; }
        public string message { get; set; }
    }

}
