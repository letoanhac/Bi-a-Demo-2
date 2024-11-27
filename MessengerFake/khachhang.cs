using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessengerFake
{
    public partial class khachhang : Form
    {
       
        void hienthikhachhang()
        {
            string str = @"Data Source=ASUSROG\SQLEXPRESS;Initial Catalog=QLAPPDEMOBI-A2;Persist Security Info=True;User ID=SA;Password=123456";
            string query = "SELECT * FROM KhachHang";

            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable tablekhachhang = new DataTable();
                    adapter.Fill(tablekhachhang);
                    dgvkhachhang.DataSource = tablekhachhang;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public khachhang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=ASUSROG\SQLEXPRESS;Initial Catalog=QLAPPDEMOBI-A2;Persist Security Info=True;User ID=SA;Password=123456"))
                {
                    connection.Open();

                    // Sử dụng tham số hóa
                    string query = "INSERT INTO KhachHang (MaKhachHang, LoaiKhach) VALUES (@MaKhachHang, @LoaiKhach)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaKhachHang", txtmakhachhang.Text);
                        command.Parameters.AddWithValue("@LoaiKhach", comboBox1.Text);
                        command.ExecuteNonQuery();
                        hienthikhachhang();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Đã xảy ra lỗi", "Lỗi", MessageBoxButtons.OK);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hienthikhachhang(); 
        }

        private void khachhang_Load(object sender, EventArgs e)
        {
            hienthikhachhang();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ASUSROG\SQLEXPRESS;Initial Catalog=QLAPPDEMOBI-A2;Persist Security Info=True;User ID=SA;Password=123456"))
            {
                connection.Open();
                string query = "delete from KhachHang where MaKhachHang = '" + txtmakhachhang.Text + "'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("MaKhachHang",txtmakhachhang.Text);
                    command.ExecuteNonQuery();
                    hienthikhachhang();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
