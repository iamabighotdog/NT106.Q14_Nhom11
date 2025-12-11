using System;
using System.Windows.Forms;
using System.Text.Json;
namespace FormAppQuyt
{
    public partial class players : Form
    {
        public players()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();

            var mainForm = Application.OpenForms["Main"] as Main;
            if (mainForm != null)
            {
                mainForm.Show();
            }
        }

        private class JoinRoomResponse
        {
            public bool ok { get; set; }
            public string message { get; set; }
            public int quizId { get; set; }
        }

        private void enterRoom_Click(object sender, EventArgs e)
        {
            string code = roomID.Text.Trim();

            if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show("Vui lòng nhập ID phòng!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                tcpClient client = new tcpClient();
                string resp = client.SendJoinRoom(code);

                var data = JsonSerializer.Deserialize<JoinRoomResponse>(resp);

                if (data != null && data.ok)
                {
                    var playForm = new playClient(data.quizId, code);
                    playForm.StartPosition = FormStartPosition.CenterScreen;
                    playForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(data?.message ?? "Không thể vào phòng!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
