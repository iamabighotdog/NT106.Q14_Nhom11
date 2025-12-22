using FormAppQuyt.Models;
using FormAppQuyt.Networking;
using FormAppQuyt.Utils;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class PlayClientForm : Form
    {
        private bool isLocked = false;
        private Guna.UI2.WinForms.Guna2Button currentSelectedBtn = null;
        private int quizId;
        private string roomId;
        private List<QuestionData> questions = new List<QuestionData>();

        private System.Windows.Forms.Timer uiTimer;
        private int timeLeftSeconds = 0;
        private int currentQuestionIndex = -1;

        private TcpSessionClient _session;

        private Guna.UI2.WinForms.Guna2HtmlLabel[] scoreLabels;

        public PlayClientForm(int quizId, string roomId)
        {
            InitializeComponent();

            InitScoreLabels();

  /*          if (myRankPopup != null)
            {
                myRankPopup.BringToFront();
                myRankPopup.Visible = false;
                if (guna2GradientPanel1 != null)
                {
                    myRankPopup.Location = new Point(
                        (guna2GradientPanel1.Width - myRankPopup.Width) / 2,
                        (guna2GradientPanel1.Height - myRankPopup.Height) / 2
                    );
                }
            }*/

            if (answerA != null) { answerA.Click -= AnswerButton_Click; answerA.Click += AnswerButton_Click; }
            if (answerB != null) { answerB.Click -= AnswerButton_Click; answerB.Click += AnswerButton_Click; }
            if (answerC != null) { answerC.Click -= AnswerButton_Click; answerC.Click += AnswerButton_Click; }
            if (answerD != null) { answerD.Click -= AnswerButton_Click; answerD.Click += AnswerButton_Click; }

            this.quizId = quizId;
            this.roomId = roomId;
            ID.Text = roomId;

            SetWaitingMode();

            uiTimer = new System.Windows.Forms.Timer();
            uiTimer.Interval = 1000;
            uiTimer.Tick += UiTimer_Tick;

            PrepareGameData();
        }

        private void InitScoreLabels()
        {
            scoreLabels = new Guna.UI2.WinForms.Guna2HtmlLabel[4];
            Guna.UI2.WinForms.Guna2Button[] btns = { answerA, answerB, answerC, answerD };

            for (int i = 0; i < 4; i++)
            {
                if (btns[i] == null) continue;

                scoreLabels[i] = new Guna.UI2.WinForms.Guna2HtmlLabel();
                scoreLabels[i].BackColor = Color.Transparent;
                scoreLabels[i].Font = new Font("Segoe UI", 14, FontStyle.Bold | FontStyle.Italic);
                scoreLabels[i].ForeColor = Color.Yellow;
                scoreLabels[i].AutoSize = true;
                scoreLabels[i].Text = "";
                scoreLabels[i].Visible = false;

                scoreLabels[i].Location = new Point(btns[i].Location.X + 45, btns[i].Location.Y + (btns[i].Height - 30) / 2);

                this.Controls.Add(scoreLabels[i]);
                scoreLabels[i].BringToFront();
            }
        }

        private async void ShowScoreEffect(Guna.UI2.WinForms.Guna2Button btn, int gained, bool correct)
        {
            if (btn == null) return;
            int index = -1;
            if (btn == answerA) index = 0;
            else if (btn == answerB) index = 1;
            else if (btn == answerC) index = 2;
            else if (btn == answerD) index = 3;

            if (index != -1 && scoreLabels[index] != null)
            {
                var lbl = scoreLabels[index];

                lbl.BackColor = btn.FillColor;
                lbl.Text = correct ? $"+{gained}" : "+0";
                lbl.ForeColor = correct ? Color.Yellow : Color.Orange;

                lbl.Visible = true;
                lbl.BringToFront();

                for (int i = 0; i < 3; i++)
                {
                    lbl.Visible = !lbl.Visible;
                    await Task.Delay(150);
                }
                lbl.Visible = true;
            }
        }

        private void ResetScoreLabels()
        {
            if (scoreLabels == null) return;
            foreach (var lbl in scoreLabels)
            {
                if (lbl != null) lbl.Visible = false;
            }
        }

        private void PrepareGameData()
        {
            LoadQuizQuestions();

            if (questions.Count == 0)
            {
                MessageBox.Show("Lỗi: Không tải được dữ liệu câu hỏi! (QuizId=" + quizId + ")");
                return;
            }

            ConnectAndJoin();
        }

        private void LoadQuizQuestions()
        {
            try
            {
                if (quizId == 0) return;

                var client = new FormAppQuyt.Networking.TcpRequestClient();
                string response = client.SendGetQuizDetails(quizId);
                var result = JsonSerializer.Deserialize<QuizDetailResponse>(response);

                if (result != null && result.ok && result.questions != null)
                {
                    questions = result.questions;
                }
                else
                {
                    MessageBox.Show("Không tải được câu hỏi từ Server.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải câu hỏi: " + ex.Message);
            }
        }

        private async void ConnectAndJoin()
        {
            try
            {
                _session = new TcpSessionClient();
                _session.OnIncomingPacket += HandleServerMessage;
                _session.Connect();
                _session.StartListening();

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
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void HandleServerMessage(string json)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            this.BeginInvoke(new Action(async () =>
            {
                try
                {
                    using (JsonDocument doc = JsonDocument.Parse(json))
                    {
                        JsonElement root = doc.RootElement;
                        string action = JsonHelper.GetString(root, "action");
                        if (string.IsNullOrEmpty(action)) return;

                        switch (action)
                        {
                            case "player_left":
                                int pc = JsonHelper.GetInt(root, "playerCount", 0);
                                players.Text = pc.ToString();
                                break;

                            case "end_game":
                                if (uiTimer != null) uiTimer.Stop();
                                this.Hide();
                                try { new LeaderBoardForm(roomId).ShowDialog(); } catch { }
                                this.Close();
                                break;

                            case "all_answered":
                                if (uiTimer != null) uiTimer.Stop();
                                if (timeBar != null)
                                {
                                    timeBar.ShowText = true;
                                    timeBar.TextMode = Guna.UI2.WinForms.Enums.ProgressBarTextMode.Custom;
                                    timeBar.Text = "Chuyển sang câu tiếp theo sau 3...2...1";
                                }
                                break;

                            case "next_question":
                                ResetScoreLabels();
                             //   if (myRankPopup != null) myRankPopup.Visible = false;

                                int idx = JsonHelper.GetInt(root, "questionIndex", -1);
                                int dur = JsonHelper.GetInt(root, "duration", 20);

                                currentQuestionIndex = idx;
                                DisplayQuestion();

                                timeLeftSeconds = dur;
                                if (timeBar != null)
                                {
                                    timeBar.Maximum = dur;
                                    timeBar.Value = dur;
                                    timeBar.Visible = true;
                                    timeBar.ShowText = true;
                                    timeBar.TextMode = Guna.UI2.WinForms.Enums.ProgressBarTextMode.Custom;
                                    timeBar.Text = "1000";
                                }
                                uiTimer.Start();
                                break;

                            case "submit_result":
                                bool correct = JsonHelper.GetBool(root, "correct", false);
                                int gained = JsonHelper.GetInt(root, "gained", 0);
                                int rank = JsonHelper.GetInt(root, "rank", 0); 

                                HighlightResult(correct);

                                ShowScoreEffect(currentSelectedBtn, gained, correct);

                                /*if (myRankPopup != null)
                                {
                                    await Task.Delay(500);
                                    await myRankPopup.ShowAnimation(rank, gained, correct);
                                }*/
                                break;

                            case "player_joined":
                                if (players != null)
                                    players.Text = JsonHelper.GetInt(root, "playerCount", 0).ToString();
                                break;
                        }
                    }
                }
                catch { }
            }));
        }

        private void SetQuestionImage_Client(string base64)
        {
            Image defaultImg = FormAppQuyt.Properties.Resources.istockphoto_1386740242_612x612;

            // mặc định trước cho chắc
            pic.Image = defaultImg;
            pic.Visible = true;

            try
            {
                if (!string.IsNullOrWhiteSpace(base64))
                {
                    byte[] bytes = Convert.FromBase64String(base64);
                    using (var ms = new MemoryStream(bytes))
                    using (var img = Image.FromStream(ms))
                    {
                        if (pic.Image != null && !ReferenceEquals(pic.Image, defaultImg))
                            pic.Image.Dispose();

                        pic.Image = new Bitmap(img); // clone ảnh
                    }
                }
            }
            catch
            {
                pic.Image = defaultImg;
            }

            pic.BringToFront();
        }

        private void SetWaitingMode()
        {
            if (question != null) question.Text = "Đang chờ chủ phòng bắt đầu...";

            answerA.Visible = true;
            answerB.Visible = true;
            answerC.Visible = true;
            answerD.Visible = true;

            // Hiện ảnh mặc định khi chờ
            SetQuestionImage_Client(null);

            if (timeBar != null) timeBar.Visible = true;
        }

        private void DisplayQuestion()
        {
            if (questions == null || questions.Count == 0) return;

            if (currentQuestionIndex < 0 || currentQuestionIndex >= questions.Count)
            {
                uiTimer.Stop();
                MessageBox.Show("Đã hết câu hỏi!", "Hoàn thành");
                ShowLeaderboard();
                Close();
                return;
            }

            var q = questions[currentQuestionIndex];

            // Ảnh: giống Host
            SetQuestionImage_Client(q.ImageBase64);

            question.Text = $"Câu {currentQuestionIndex + 1}: {q.NoiDung}";
            this.Text = "Đang chơi...";

            var answers = new List<string> { q.DapAnDung, q.DapAnSai1, q.DapAnSai2, q.DapAnSai3 }
                .OrderBy(_ => FormAppQuyt.Utils.RandomProvider.Shared.Next())
                .ToList();

            answerA.Text = "A. " + answers[0];
            answerB.Text = "B. " + answers[1];
            answerC.Text = "C. " + answers[2];
            answerD.Text = "D. " + answers[3];

            Color defaultColor = Color.Green;
            answerA.FillColor = defaultColor; answerB.FillColor = defaultColor;
            answerC.FillColor = defaultColor; answerD.FillColor = defaultColor;

            // MỞ KHÓA để click được
            isLocked = false;
            currentSelectedBtn = null;

            // HIỆN + ENABLE buttons
            answerA.Visible = true; answerB.Visible = true;
            answerC.Visible = true; answerD.Visible = true;

            answerA.Enabled = true; answerB.Enabled = true;
            answerC.Enabled = true; answerD.Enabled = true;
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

        private void UiTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeftSeconds > 0)
            {
                timeLeftSeconds--;
                if (timeBar != null && timeBar.Maximum > 0)
                {
                    timeBar.Value = timeLeftSeconds;

                    if (!isLocked)
                    {
                        double maxTime = (double)timeBar.Maximum;
                        double ratio = (double)timeLeftSeconds / maxTime;
                        int potentialScore = 500 + (int)(500 * ratio);

                        timeBar.ShowText = true;
                        timeBar.TextMode = Guna.UI2.WinForms.Enums.ProgressBarTextMode.Custom;
                        timeBar.Text = potentialScore.ToString();
                        if (timeLeftSeconds < 5)
                            timeBar.ForeColor = Color.Red;
                        else
                            timeBar.ForeColor = Color.Black;
                    }
                    else
                        timeBar.ForeColor = Color.Black;
                }
            }
            else
            {
                uiTimer.Stop();
                isLocked = true;
                if (timeBar != null) timeBar.Text = "0";
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            _session?.Dispose();
            Close();
            var pForm = Application.OpenForms["players"] as PlayersForm;
            if (pForm != null) pForm.Show();
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            uiTimer?.Stop();
            _session?.Dispose();
            base.OnFormClosing(e);
        }
    }
}