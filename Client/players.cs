using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
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
            if (string.IsNullOrWhiteSpace(code)) { MessageBox.Show("Nhập ID đi bạn ơi!"); return; }

            try
            {
                tcpClient client = new tcpClient();
                string resp = client.SendRoomGetState(code);
                var data = JsonSerializer.Deserialize<Dictionary<string, object>>(resp);

                if (data.ContainsKey("ok") && data["ok"].ToString().ToLower() == "true")
                {
                    int qId = 0;
                    if (data.ContainsKey("quizId"))
                        int.TryParse(data["quizId"].ToString(), out qId);

                    var playForm = new playClient(qId, code);
                    playForm.StartPosition = FormStartPosition.CenterScreen;
                    playForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Phòng không tồn tại hoặc đã đóng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
