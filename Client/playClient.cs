using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class playClient : Form
    {
        private int quizId;
        private string roomId;
        private List<QuestionData> questions = new List<QuestionData>();
        private System.Windows.Forms.Timer roomTimer;
        private int currentQuestionIndex = -1;
        private int durationSeconds = 0;
        private int timeLeftSeconds = 0;

        public playClient()
        {
            InitializeComponent();
            WireEvents();
        }
        private class RoomStateResponse
        {
            public bool ok { get; set; }
            public string message { get; set; }
            public int currentQuestionIndex { get; set; }
            public int durationSeconds { get; set; }
            public int timeLeftSeconds { get; set; }
            public int playerCount { get; set; }
        }

        private class SubmitAnswerResponse
        {
            public bool ok { get; set; }
            public bool correct { get; set; }
            public int gained { get; set; }
            public int score { get; set; }
            public int timeLeft { get; set; }
            public string message { get; set; }
        }


        public playClient(string roomId) : this()
        {
            this.roomId = roomId;
            ID.Text = roomId;

        }

        public playClient(int quizId, string roomId) : this()
        {
            this.quizId = quizId;
            this.roomId = roomId;
            ID.Text = roomId;

            LoadQuizQuestions();
            SetWaitingMode();
            StartRoomTimer();
        }
        private void SetWaitingMode()
        {
            question.Text = "Đang chờ chủ phòng bắt đầu...";
            question.Visible = true;

            answerA.Visible = false;
            answerB.Visible = false;
            answerC.Visible = false;
            answerD.Visible = false;

            pic.Visible = false;
            timeBar.Visible = false;
            next.Visible = false;
        }
        private void WireEvents()
        {
            answerA.Click += AnswerButton_Click;
            answerB.Click += AnswerButton_Click;
            answerC.Click += AnswerButton_Click;
            answerD.Click += AnswerButton_Click;

            next.Click += next_Click;
            back.Click += back_Click;
        }
        private void StartRoomTimer()
        {
            roomTimer = new Timer();
            roomTimer.Interval = 1000; 
            roomTimer.Tick += RoomTimer_Tick;
            roomTimer.Start();
        }

        private void RoomTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                tcpClient client = new tcpClient();
                string resp = client.SendRoomGetState(roomId);
                var state = JsonSerializer.Deserialize<RoomStateResponse>(resp);

                if (state == null || !state.ok) return;

                if (players != null)
                    players.Text = state.playerCount.ToString();
                if (state.currentQuestionIndex == -1)
                {
                    SetWaitingMode(); 
                    return; 
                }

                if (state.currentQuestionIndex != currentQuestionIndex)
                {
                    currentQuestionIndex = state.currentQuestionIndex;

                    DisplayQuestion();
                    answerA.Visible = true; answerA.Enabled = true; answerA.FillColor = Color.Green;
                    answerB.Visible = true; answerB.Enabled = true; answerB.FillColor = Color.Green;
                    answerC.Visible = true; answerC.Enabled = true; answerC.FillColor = Color.Green;
                    answerD.Visible = true; answerD.Enabled = true; answerD.FillColor = Color.Green;
                    pic.Visible = true;
                    timeBar.Visible = true;
                    timeBar.Maximum = state.durationSeconds;
                    this.Text = "Play"; 
                }

                timeLeftSeconds = state.timeLeftSeconds;
                if (timeBar.Maximum > 0)
                    timeBar.Value = timeLeftSeconds > 0 ? timeLeftSeconds : 0;
                if (timeLeftSeconds <= 0)
                {
                    if (answerA.Enabled)
                    {
                        answerA.Enabled = false; answerB.Enabled = false;
                        answerC.Enabled = false; answerD.Enabled = false;
                    }
                }

                if (currentQuestionIndex >= questions.Count - 1 && timeLeftSeconds <= 0)
                {
                    roomTimer.Stop();

                    // LƯU ROOMID
                    Global.LastPlayedRoomId = roomId;

                    // Delay một chút để người chơi thấy câu cuối
                    System.Threading.Thread.Sleep(1000);

                    // HIỂN THỊ LEADERBOARD
                    ShowLeaderboard();

                    MessageBox.Show("Chúc mừng bạn đã hoàn thành!", "Thông báo");
                    Close();
                }
            }
            catch { }
        }
        private void ResetAnswerButtons()
        {
            answerA.Enabled = true; answerA.FillColor = Color.Green;
            answerB.Enabled = true; answerB.FillColor = Color.Green;
            answerC.Enabled = true; answerC.FillColor = Color.Green;
            answerD.Enabled = true; answerD.FillColor = Color.Green;
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

        private void LoadQuizQuestions()
        {
            if (quizId == 0) return;   

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
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void DisplayQuestion()
        {
            if (questions.Count == 0)
                return;

            if (currentQuestionIndex < 0) return;

            if (currentQuestionIndex >= questions.Count)
            {
                roomTimer.Stop();
                MessageBox.Show("Chúc mừng bạn đã hoàn thành", "Thông báo");
                Close();
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

            next.Text = (currentQuestionIndex == questions.Count - 1)
                ? "Kết thúc"
                : "Tiếp theo";
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Guna.UI2.WinForms.Guna2Button;
            if (btn == null) return;

            string chosen = btn.Text;
            int dot = chosen.IndexOf(". ");
            if (dot >= 0) chosen = chosen.Substring(dot + 2);
            chosen = chosen.Trim();

            try
            {
                tcpClient client = new tcpClient();
                string resp = client.SendSubmitAnswer(roomId, Global.UserId, chosen);
                var result = JsonSerializer.Deserialize<SubmitAnswerResponse>(resp);

                if (result == null || !result.ok)
                {
                    MessageBox.Show(result?.message ?? "Submit lỗi", "Lỗi");
                    return;
                }

                if (result.correct)
                {
                    btn.FillColor = Color.FromArgb(0, 192, 0);
                    MessageBox.Show($"ĐÚNG +{result.gained} điểm\nTổng: {result.score}", "Kết quả");
                }
                else
                {
                    btn.FillColor = Color.Red;
                    HighlightCorrectAnswer();
                    MessageBox.Show($"SAI +0 điểm\nTổng: {result.score}", "Kết quả");
                }

                answerA.Enabled = answerB.Enabled = answerC.Enabled = answerD.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi submit: " + ex.Message);
            }
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
            currentQuestionIndex++;

            if (currentQuestionIndex < questions.Count)
            {
                DisplayQuestion();
            }
            else
            {
                MessageBox.Show($"Đã hết câu hỏi! Tổng cộng {questions.Count} câu.",
                    "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
       

        private void back_Click(object sender, EventArgs e)
        {
            Close();

            var pForm = Application.OpenForms["players"] as players;
            if (pForm != null)
                pForm.Show();
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
