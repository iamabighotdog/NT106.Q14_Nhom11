using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
using FormAppQuyt.Networking;
namespace FormAppQuyt
{
    public partial class MyQuizForm : Form
    {
        private int currentUserId;
        public MyQuizForm(int userId)
        {
            InitializeComponent();
            currentUserId = userId;

            LoadQuiz();
            gridQuiz.CellDoubleClick += GridQuiz_CellDoubleClick;
        }
        private void LoadQuiz()
        {
            gridQuiz.Rows.Clear();

            TcpRequestClient client = new TcpRequestClient();
            string raw = client.SendGetMyQuiz(currentUserId);

            var res = JsonSerializer.Deserialize<GetQuizResponse>(raw);

            if (res == null || !res.ok)
            {
                MessageBox.Show(res?.message ?? "Không load được danh sách");
                return;
            }

            foreach (var q in res.data)
            {
                gridQuiz.Rows.Add(
                    q.name,
                    q.total,
                    q.date,
                    q.id
                );
            }
        }
        private void remove_Click(object sender, EventArgs e)
        {
            if (gridQuiz.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn bộ đề cần xóa");
                return;
            }

            var row = gridQuiz.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["id"].Value);
            string name = row.Cells["name"].Value.ToString();

            if (MessageBox.Show($"Xóa '{name}' ?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            TcpRequestClient client = new TcpRequestClient();
            string raw = client.SendDeleteQuiz(id);
            var res = JsonSerializer.Deserialize<BasicResponse>(raw);

            if (res.ok)
            {
                gridQuiz.Rows.Remove(row);
                MessageBox.Show("Đã xóa");
            }
            else
            {
                MessageBox.Show(res.message);
            }
        }
        private void GridQuiz_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                gridQuiz.Rows[e.RowIndex].Selected = true;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class QuizItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public int total { get; set; }
        public string date { get; set; }
    }

    public class GetQuizResponse
    {
        public bool ok { get; set; }
        public List<QuizItem> data { get; set; }
        public string message { get; set; }
    }

    public class BasicResponse
    {
        public bool ok { get; set; }
        public string message { get; set; }
    }
}
