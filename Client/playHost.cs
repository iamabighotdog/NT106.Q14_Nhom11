using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class playHost : Form
    {
        private int quizId;
        private string quizName;
        private string roomId;
        private List<QuestionData> questions = new List<QuestionData>();
        private int currentQuestionIndex = 0;
        private bool gameStarted = false;
        public playHost(int selectedQuizId, string selectedQuizName)
        {
            InitializeComponent();
            quizId = selectedQuizId;
            quizName = selectedQuizName;

            roomId = GenerateRoomId();
            ID.Text = roomId;

            LoadQuizQuestions();
            InitializeWaitingRoom();
        }

        private class QuestionData
        {
            public int Id { get; set; }
            public string NoiDung { get; set; }
            public string DapAnDung { get; set; }
            public string DapAnSai1 { get; set; }
            public string DapAnSai2 { get; set; }
            public string DapAnSai3 { get; set; }
            public string ImageBase64 { get; set; }
        }

        private class QuizDetailResponse
        {
            public bool ok { get; set; }
            public string message { get; set; }
            public List<QuestionData> questions { get; set; }
        }

        private string GenerateRoomId()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void LoadQuizQuestions()
        {
            try
            {
                tcpClient client = new tcpClient();
                string response = client.SendGetQuizDetails(quizId);

                var result = JsonSerializer.Deserialize<QuizDetailResponse>(response);

                if (result != null && result.ok && result.questions != null)
                {
                    questions = result.questions;
                }
                else
                {
                    MessageBox.Show(result?.message ?? "Không thể tải câu hỏi!",
                                  "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void InitializeWaitingRoom()
        {
            question.Visible = false;
            answerA.Visible = false;
            answerB.Visible = false;
            answerC.Visible = false;
            answerD.Visible = false;
            pic.Visible = false;
            next.Visible = false;

            players.Text = "0";

            playBtn.Visible = true;
            playBtn.Enabled = true;
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (questions.Count == 0)
            {
                MessageBox.Show("Không có câu hỏi để chơi!", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            gameStarted = true;
            playBtn.Visible = false;

            question.Visible = true;
            answerA.Visible = true;
            answerB.Visible = true;
            answerC.Visible = true;
            answerD.Visible = true;
            pic.Visible = true;
            next.Visible = true;

            guna2HtmlLabel2.Visible = false;
            players.Visible = false;

            currentQuestionIndex = 0;
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex >= questions.Count)
            {
                MessageBox.Show($"Đã hết câu hỏi! Tổng cộng {questions.Count} câu.",
                              "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            var q = questions[currentQuestionIndex];

            question.Text = $"Câu {currentQuestionIndex + 1}/{questions.Count}: {q.NoiDung}";

            var answers = new List<(string text, bool isCorrect)>
            {
                (q.DapAnDung, true),
                (q.DapAnSai1, false),
                (q.DapAnSai2, false),
                (q.DapAnSai3, false)
            };

            Random rng = new Random();
            answers = answers.OrderBy(x => rng.Next()).ToList();

            answerA.Text = "A. " + answers[0].text;
            answerA.Tag = answers[0].isCorrect;
            answerA.FillColor = Color.Green;

            answerB.Text = "B. " + answers[1].text;
            answerB.Tag = answers[1].isCorrect;
            answerB.FillColor = Color.Green;

            answerC.Text = "C. " + answers[2].text;
            answerC.Tag = answers[2].isCorrect;
            answerC.FillColor = Color.Green;

            answerD.Text = "D. " + answers[3].text;
            answerD.Tag = answers[3].isCorrect;
            answerD.FillColor = Color.Green;

            if (!string.IsNullOrEmpty(q.ImageBase64))
            {
                try
                {
                    byte[] bytes = Convert.FromBase64String(q.ImageBase64);
                    using (var ms = new MemoryStream(bytes))
                    {
                        pic.Image = Image.FromStream(ms);
                    }
                    pic.Visible = true;
                }
                catch
                {
                    pic.Visible = false;
                }
            }
            else
            {
                pic.Image = null;
                pic.Visible = false;
            }

            if (currentQuestionIndex == questions.Count - 1)
            {
                next.Text = "Kết thúc";
            }
            else
            {
                next.Text = "Tiếp theo";
            }
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            if (!gameStarted) return;

            var btn = sender as Guna.UI2.WinForms.Guna2Button;
            if (btn == null) return;

            bool isCorrect = (bool)btn.Tag;

            if (isCorrect)
            {
                btn.FillColor = Color.FromArgb(0, 192, 0);
                MessageBox.Show("Đúng rồi!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btn.FillColor = Color.Red;
                HighlightCorrectAnswer();
                MessageBox.Show("Sai rồi!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HighlightCorrectAnswer()
        {
            foreach (var btn in new[] { answerA, answerB, answerC, answerD })
            {
                if ((bool)btn.Tag)
                {
                    btn.FillColor = Color.FromArgb(0, 192, 0);
                }
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            currentQuestionIndex++;
            DisplayQuestion();
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                var result = MessageBox.Show("Bạn có chắc muốn thoát? Trò chơi sẽ kết thúc.",
                                           "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
            }

            this.Close();
        }
    }
}
