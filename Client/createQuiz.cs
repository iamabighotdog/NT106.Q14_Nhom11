using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class createQuiz : Form
    {
        public createQuiz()
        {
            InitializeComponent();
        }
        private void addPic_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Ảnh .jpg|*.jpg;*.jpeg|Ảnh .png|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] bytes = File.ReadAllBytes(ofd.FileName);
                if (bytes.Length > 200 * 1024)
                {
                    MessageBox.Show("Ảnh quá lớn! < 200KB");
                    return;
                }

                _imageBase64 = Convert.ToBase64String(bytes);
                picImage.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text)) return;

            QuizQuestion q = new QuizQuestion
            {
                NoiDung = txtNoiDung.Text.Trim(),
                DapAnDung = txtDung.Text.Trim(),
                Sai1 = txtSai1.Text.Trim(),
                Sai2 = txtSai2.Text.Trim(),
                Sai3 = txtSai3.Text.Trim(),
                ImageBase64 = _imageBase64
            };

            if (currentIndex >= _questions.Count)
                _questions.Add(q);
            else
                _questions[currentIndex] = q;
        }
    }
}
