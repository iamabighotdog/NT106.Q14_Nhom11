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
        private byte[] selectedImage = null;
        public createQuiz()
        {
            InitializeComponent();
        }

        private void addPic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    FileInfo fileInfo = new FileInfo(filePath);

                    const int MAX_FILE_SIZE_BYTES = 500 * 1024;  

                    if (fileInfo.Length > MAX_FILE_SIZE_BYTES)
                    {
                        MessageBox.Show("Kích thước file ảnh quá lớn (> 500KB). Vui lòng chọn ảnh nhỏ hơn.",
                                        "Cảnh báo Kích thước", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        selectedImage = null;
                        return;
                    }

                    try
                    {

                        selectedImage = File.ReadAllBytes(filePath);

                        using (MemoryStream ms = new MemoryStream(selectedImage))
                        {
                            pic.Image = Image.FromStream(ms);
                        }

                        MessageBox.Show("Đã chọn ảnh thành công.", "Thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi đọc file: " + ex.Message, "Lỗi");
                    }
                }
            }
        }
    }
}
