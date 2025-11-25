using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class createQuiz : Form
    {
        private string _imageBase64 = null;
        private List<QuizQuestion> _questions = new List<QuizQuestion>();
        private int currentIndex = 0;

        public createQuiz()
        {
            InitializeComponent();
        }
        private void SendQuestion(QuizQuestion q)
        {
            try
            {
                var dict = new Dictionary<string, string>()
            {
                {"action", "create_question"},
                {"NoiDung", q.NoiDung},
                {"DapAnDung", q.DapAnDung},
                {"Sai1", q.Sai1},
                {"Sai2", q.Sai2},
                {"Sai3", q.Sai3},
                {"ImageBase64", q.ImageBase64 ?? "" }
            };
                string json = System.Text.Json.JsonSerializer.Serialize(dict);

                using (TcpClient client = new TcpClient())
                {
                    client.Connect("127.0.0.1", 3636);
                    using (var stream = client.GetStream())
                    {
                        byte[] data = Encoding.UTF8.GetBytes(json + "\n");
                        stream.Write(data, 0, data.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi server: " + ex.Message);
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

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(quesBox.Text)
             || string.IsNullOrWhiteSpace(correctBox.Text)
             || string.IsNullOrWhiteSpace(wrongBox1.Text)
             || string.IsNullOrWhiteSpace(wrongBox2.Text)
             || string.IsNullOrWhiteSpace(wrongBox3.Text))
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu câu hỏi");
                return;
            }

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

            currentIndex++;
            SendQuestion(q);
            ClearInputs();
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
}
