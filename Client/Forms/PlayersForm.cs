using FormAppQuyt.Networking;
using FormAppQuyt.Utils;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
namespace FormAppQuyt
{
    public partial class PlayersForm : Form
    {
        public PlayersForm()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();

            var main = Application.OpenForms["MainForm"];
            if (main != null) main.Show();
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
                TcpRequestClient client = new TcpRequestClient();
                string resp = client.SendRoomGetState(code);

                using (JsonDocument doc = JsonDocument.Parse(resp))
                {
                    JsonElement root = doc.RootElement;

                    bool ok = JsonHelper.GetBool(root, "ok", false);
                    if (ok)
                    {
                        int qId = JsonHelper.GetInt(root, "quizId", 0);

                        var playForm = new PlayClientForm(qId, code);
                        playForm.StartPosition = FormStartPosition.CenterScreen;
                        playForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Phòng không tồn tại hoặc đã đóng.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
