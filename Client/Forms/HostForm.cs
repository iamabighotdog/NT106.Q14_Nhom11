using FormAppQuyt.Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class HostForm : Form
    {
        private List<QuizItem> quizList = new List<QuizItem>();
        public HostForm()
        {
            InitializeComponent();
            LoadQuizList();
        }

        private class QuizItem
        {
            public int id { get; set; }
            public string name { get; set; }
            public int total { get; set; }
            public string date { get; set; }
        }

        private class QuizListResponse
        {
            public bool ok { get; set; }
            public string message { get; set; }
            public List<QuizItem> data { get; set; }
        }

        private void LoadQuizList()
        {
            try
            {
                TcpRequestClient client = new TcpRequestClient();
                string response = client.SendGetMyQuiz(Global.UserId);

                var result = JsonSerializer.Deserialize<QuizListResponse>(response);

                if (result != null && result.ok && result.data != null)
                {
                    if (result.data.Count == 0)
                    {
                        MessageBox.Show("Bạn chưa có bộ câu hỏi nào. Vui lòng tạo bộ câu hỏi trước!",
                                      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }

                    quizList = result.data;

                    listView1.View = View.Details;
                    listView1.FullRowSelect = true;
                    listView1.GridLines = true;
                    listView1.Items.Clear();

                    foreach (var quiz in quizList)
                    {
                        ListViewItem item = new ListViewItem(quiz.name);
                        item.SubItems.Add(quiz.total.ToString() + " câu");
                        item.SubItems.Add(quiz.date);
                        item.Tag = quiz.id; 
                        listView1.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show(result?.message ?? "Không thể tải danh sách câu hỏi!",
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

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();

            var main = Application.OpenForms["MainForm"];
            if (main != null) main.Show();
        }

        private void choose_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bộ câu hỏi!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedQuizId = (int)listView1.SelectedItems[0].Tag;
            string quizName = listView1.SelectedItems[0].Text;

            this.Hide();
            PlayHostForm playForm = new PlayHostForm(selectedQuizId, quizName);
            playForm.StartPosition = FormStartPosition.CenterScreen;
            playForm.ShowDialog();
            this.Close();
        }
    }
}
