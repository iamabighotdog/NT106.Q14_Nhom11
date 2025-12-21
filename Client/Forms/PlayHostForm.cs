using FormAppQuyt.Networking;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using FormAppQuyt.Models;

namespace FormAppQuyt
{
    public partial class PlayHostForm : Form
    {
        private bool isTransitioning = false;
        private DateTime lastQuestionTime = DateTime.MinValue;
        private bool isLocked = false;
        private Guna.UI2.WinForms.Guna2Button currentSelectedBtn = null; 
        private int quizId;
        private string quizName;
        private string roomId;
        private List<QuestionData> questions = new List<QuestionData>();
        private int currentQuestionIndex = -1;

        private System.Windows.Forms.Timer autoNextTimer;
        private int timeLeft = 0;
        private const int QUESTION_DURATION = 20;

        private TcpSessionClient _session;

        public PlayHostForm(int selectedQuizId, string selectedQuizName)
        {
            InitializeComponent();

            if (playBtn != null) { playBtn.Click -= playBtn_Click; playBtn.Click += playBtn_Click; }

            if (answerA != null) { answerA.Click -= AnswerButton_Click; answerA.Click += AnswerButton_Click; }
            if (answerB != null) { answerB.Click -= AnswerButton_Click; answerB.Click += AnswerButton_Click; }
            if (answerC != null) { answerC.Click -= AnswerButton_Click; answerC.Click += AnswerButton_Click; }
            if (answerD != null) { answerD.Click -= AnswerButton_Click; answerD.Click += AnswerButton_Click; }

            quizId = selectedQuizId;
            quizName = selectedQuizName;

            roomId = GenerateRoomId();
            ID.Text = roomId;

            autoNextTimer = new System.Windows.Forms.Timer();
            autoNextTimer.Interval = 1000;
            autoNextTimer.Tick += AutoNextTimer_Tick;

            LoadQuizQuestions();

            if (questions.Count > 0)
            {
                InitNetwork();
            }
        }

        private async void InitNetwork()
        {
            try
            {
                _session = new TcpSessionClient();
                _session.OnIncomingPacket += HandleServerMessage;
                _session.Connect();
                _session.StartListening();

                await Task.Delay(500);

                _session.Send(new
                {
                    action = "create_room",
                    userId = Global.UserId,
                    quizId = quizId,
                    roomId = roomId
                });

                await Task.Delay(200);

                _session.Send(new
                {
                    action = "join_room",
                    roomId = roomId,
                    userId = Global.UserId
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mạng: " + ex.Message);
            }
        }

        private void AutoNextTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                if (ProgressBar1 != null)
                {
                    ProgressBar1.Value = timeLeft;

                    if (!isLocked)
                    {
                        double ratio = (double)timeLeft / ProgressBar1.Maximum;
                        int potentialScore = 500 + (int)(500 * ratio);

                        ProgressBar1.ShowText = true;
                        ProgressBar1.TextMode = Guna.UI2.WinForms.Enums.ProgressBarTextMode.Custom;
                        ProgressBar1.Text = potentialScore.ToString();
                    }
                }
            }
            else
            {
                autoNextTimer.Stop();
                if (!isTransitioning)
                {
                    PerformNextQuestion();
                }
            }
        }

        private void PerformNextQuestion()
        {
            if ((DateTime.Now - lastQuestionTime).TotalSeconds < 2) return;
            lastQuestionTime = DateTime.Now;
            if (_session == null || !_session.IsConnected)
            {
                try { _session?.Dispose(); } catch { }
                InitNetwork();
                return;
            }


            autoNextTimer.Stop();
            currentQuestionIndex++;

            if (currentQuestionIndex < questions.Count)
            {
                DisplayQuestion();

                int duration = questions[currentQuestionIndex].TimeLimit;
                if (duration <= 0) duration = 20;

                _session.Send(new
                {
                    action = "room_start_question",
                    roomId = roomId,
                    questionIndex = currentQuestionIndex,
                    durationSeconds = duration
                });

                if (playBtn != null) playBtn.Enabled = false;


                timeLeft = duration;
                if (ProgressBar1 != null)
                {
                    ProgressBar1.Maximum = duration;
                    ProgressBar1.Value = duration;
                    ProgressBar1.Text = "1000";
                    ProgressBar1.ShowText = true;
                }
                autoNextTimer.Start();
                isTransitioning = false; 
            }
            else
            {
                if (_session != null && _session.IsConnected)
                {
                    _session.Send(new { action = "end_game", roomId = roomId });
                }
                autoNextTimer.Stop();
                MessageBox.Show("Đã hết câu hỏi! Kết thúc game.");
                Global.LastPlayedRoomId = roomId;
                ShowLeaderboard();
                Close();
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex >= 0) return;
            if (isTransitioning) return;

            PerformNextQuestion();
        }

        private void HandleServerMessage(string json)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            this.Invoke((MethodInvoker)async delegate
            {
                try
                {
                    var data = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
                    if (!data.ContainsKey("action")) return;

                    string action = data["action"].ToString();

                    switch (action)
                    {
                        case "player_joined":
                            if (players != null)
                                players.Text = data["playerCount"].ToString();
                            break;
                        case "all_answered":
                            if (isTransitioning) return;
                            isTransitioning = true;
                            if (autoNextTimer != null) autoNextTimer.Stop();

                            if (ProgressBar1 != null)
                            {
                                ProgressBar1.ShowText = true;
                                ProgressBar1.Text = "Sang câu tiếp theo trong 3...2...1";
                            }
                            int indexBeforeWait = currentQuestionIndex;
                            await Task.Delay(3000);
                            if (indexBeforeWait != currentQuestionIndex)
                            {
                                isTransitioning = false;
                                return;
                            }
                            PerformNextQuestion();
                            break;

                        case "submit_result":
                            bool correct = bool.Parse(data["correct"].ToString());
                            int score = int.Parse(data["score"].ToString());
                            int gained = data.ContainsKey("gained") ? int.Parse(data["gained"].ToString()) : 0;

                            HighlightResult(correct);

                            this.Refresh();
                            Application.DoEvents();

                            await Task.Delay(500);

                            if (correct)
                                MessageBox.Show($"CHỦ PHÒNG ĐÚNG!\n+{gained} điểm\nTổng: {score}");
                            else
                                MessageBox.Show($"SAI RỒI!\n+0 điểm\nTổng: {score}");
                            break;
                    }
                }
                catch { }
            });
        }


        private void HighlightResult(bool correct)
        {
            var currentQ = questions[currentQuestionIndex];
            string correctText = currentQ.DapAnDung.Trim();

            if (currentSelectedBtn != null)
            {
                if (correct)
                    currentSelectedBtn.FillColor = Color.FromArgb(0, 192, 0);
                else
                    currentSelectedBtn.FillColor = Color.Red;
            }

            Guna.UI2.WinForms.Guna2Button[] buttons = { answerA, answerB, answerC, answerD };
            foreach (var btn in buttons)
            {
                if (btn == null) continue;

                string btnText = btn.Text.Trim();
                int dotIndex = btnText.IndexOf('.');
                if (dotIndex >= 0 && dotIndex < 4)
                    btnText = btnText.Substring(dotIndex + 1).Trim();

                if (string.Equals(btnText, correctText, StringComparison.OrdinalIgnoreCase))
                {
                    btn.FillColor = Color.FromArgb(0, 192, 0);
                }
            }
        }

        private void DisplayQuestion()
        {
            if (questions.Count == 0 || currentQuestionIndex < 0) return;
            var q = questions[currentQuestionIndex];

            if (question != null) question.Text = $"Câu {currentQuestionIndex + 1}: {q.NoiDung}";

            var answers = new List<string> { q.DapAnDung, q.DapAnSai1, q.DapAnSai2, q.DapAnSai3 };
            answers = answers.OrderBy(_ => FormAppQuyt.Utils.RandomProvider.Shared.Next()).ToList();


            answerA.Text = "A. " + answers[0];
            answerB.Text = "B. " + answers[1];
            answerC.Text = "C. " + answers[2];
            answerD.Text = "D. " + answers[3];

            Color defaultColor = Color.Green;
            answerA.FillColor = defaultColor;
            answerB.FillColor = defaultColor;
            answerC.FillColor = defaultColor;
            answerD.FillColor = defaultColor;
            isLocked = false;
            currentSelectedBtn = null;

            if (!string.IsNullOrEmpty(q.ImageBase64))
            {
                try
                {
                    byte[] bytes = Convert.FromBase64String(q.ImageBase64);
                    using (var ms = new MemoryStream(bytes)) pic.Image = Image.FromStream(ms);
                    pic.Visible = true;
                }
                catch { pic.Visible = false; }
            }
            else pic.Visible = false;
        }

        private void AnswerButton_Click(object sender, EventArgs e)
        {
            if (isLocked) return;
            var btn = sender as Guna.UI2.WinForms.Guna2Button;
            if (btn == null) return;

            isLocked = true;
            currentSelectedBtn = btn;
            string chosen = btn.Text;
            int dot = chosen.IndexOf(". ");
            if (dot >= 0) chosen = chosen.Substring(dot + 2);
            chosen = chosen.Trim();

            _session.Send(new
            {
                action = "submit_answer",
                roomId = roomId,
                userId = Global.UserId,
                answer = chosen
            });

            btn.FillColor = Color.Orange;
        }

        private string GenerateRoomId()
        {
            Random r = new Random();
            return r.Next(10000, 99999).ToString();
        }

        private void LoadQuizQuestions()
        {
            try
            {
                TcpRequestClient client = new TcpRequestClient();
                string response = client.SendGetQuizDetails(quizId);
                var result = JsonSerializer.Deserialize<QuizDetailResponse>(response);

                if (result != null && result.ok && result.questions != null)
                {
                    questions = result.questions;
                }
                else
                {
                    MessageBox.Show(result?.message ?? "Không tải được câu hỏi.");
                    if (playBtn != null) playBtn.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            autoNextTimer?.Stop();
            _session?.Dispose();
            Close();
        }

        private void ShowLeaderboard()
        {
            try
            {
                LeaderBoardForm leaderboardForm = new LeaderBoardForm(roomId);
                leaderboardForm.ShowDialog();
            }
            catch { }
        }
    }
}