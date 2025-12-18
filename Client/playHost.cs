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
        private Timer hostTimer;
        private int timeLeft = 20;
        public playHost(int selectedQuizId, string selectedQuizName)
        {
            InitializeComponent();
            quizId = selectedQuizId;
            quizName = selectedQuizName;

            roomId = GenerateRoomId();
            ID.Text = roomId;
            CreateRoomOnServer();     


            LoadQuizQuestions();
            InitializeWaitingRoom();
            hostTimer = new Timer();
            hostTimer.Interval = 1000;
            hostTimer.Tick += HostTimer_Tick; 
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
        private class CreateRoomResponse
        {
            public bool ok { get; set; }
            public string message { get; set; }
            public string roomId { get; set; }
            public int quizId { get; set; }
        }

        private void CreateRoomOnServer()
        {
            try
            {
                tcpClient client = new tcpClient();
                string response = client.SendCreateRoom(Global.UserId, quizId, roomId);

                var result = JsonSerializer.Deserialize<CreateRoomResponse>(response);

                if (result == null || !result.ok)
                {
                    MessageBox.Show(result?.message ?? "Không thể tạo phòng!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            MessageBox.Show($"Mã phòng của bạn là: {roomId}\nGửi mã này cho người chơi để vào phòng.",
                "Tạo phòng thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void HostTimer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value > 0)
            {
                progressBar1.Value--; 
            }
            else
            {
                hostTimer.Stop();
                next.PerformClick();
            }
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
            var client = new tcpClient();
            client.SendRoomStartQuestion(roomId, currentQuestionIndex, 20);
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
            timeLeft = 20; 
            progressBar1.Maximum = timeLeft;
            progressBar1.Value = timeLeft;

            hostTimer.Start();

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
            ResetHostButtons();

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
            var btn = sender as Guna.UI2.WinForms.Guna2Button;
            if (btn == null) return;

            bool isCorrect = (bool)(btn.Tag ?? false);

            if (isCorrect)
            {
                btn.FillColor = Color.FromArgb(0, 192, 0); 
                                                      
                this.Text = "Host: Bạn đã chọn ĐÚNG!";
                MessageBox.Show("Chính xác! Bạn giỏi quá.", "Kết quả",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btn.FillColor = Color.Red;
                HighlightCorrectAnswer();
                this.Text = "Host: Bạn đã chọn SAI!";
                MessageBox.Show("Sai mất rồi!", "Kết quả",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            answerA.Enabled = false;
            answerB.Enabled = false;
            answerC.Enabled = false;
            answerD.Enabled = false;
        }
        private void HighlightCorrectAnswer()
        {
            foreach (var b in new[] { answerA, answerB, answerC, answerD })
            {
                if ((bool)(b.Tag ?? false))
                {
                    b.FillColor = Color.FromArgb(0, 192, 0);
                }
            }
        }

      

        private void next_Click(object sender, EventArgs e)
        {
            hostTimer.Stop();
            currentQuestionIndex++;
            if (currentQuestionIndex >= questions.Count)
            {
                hostTimer.Stop();

                Global.LastPlayedRoomId = roomId;
                MessageBox.Show($"Đã hết câu hỏi! Tổng cộng {questions.Count} câu.",
                                "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowLeaderboard();
                this.Close();
                return;
            }

            var client = new tcpClient();
            client.SendRoomStartQuestion(roomId, currentQuestionIndex, 20);

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
            hostTimer.Stop();
            this.Close();
        }
        private void ResetHostButtons()
        {
            answerA.Enabled = true;
            answerB.Enabled = true;
            answerC.Enabled = true;
            answerD.Enabled = true;

            answerA.FillColor = Color.Green;
            answerB.FillColor = Color.Green;
            answerC.FillColor = Color.Green;
            answerD.FillColor = Color.Green;

            this.Text = "Play"; 
        }

        private void ShowLeaderboard()
        {
            try
            {
                leaderboard leaderboardForm = new leaderboard(roomId);
                leaderboardForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể hiển thị bảng xếp hạng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
