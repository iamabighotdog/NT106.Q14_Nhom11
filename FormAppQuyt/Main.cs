using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormAppQuyt
{
    public partial class Main : Form
    {
        private string userInput;
        string connectionString = ConfigurationManager.ConnectionStrings["UserAuthDB"].ConnectionString;
        public Main(string input)
        {
            InitializeComponent();
            userInput = input;

        }
        private void Main_Load(object sender, EventArgs e)
        {
            string query = "SELECT Username, Email, Phone FROM Users WHERE Email=@input OR Username=@input OR Phone=@input";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@input", userInput);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Username.Text = reader["Username"].ToString();
                            Email.Text = reader["Email"].ToString();
                            PhoneNumber.Text = reader["Phone"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin người dùng!");
                        }
                    }
                }
            }

        }

        
    }
}
