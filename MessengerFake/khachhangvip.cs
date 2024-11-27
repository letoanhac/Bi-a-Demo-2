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
    public partial class khachhangvip : Form
    {
        void hienthikhachvip()
        {
            string str = @"Data Source=ASUSROG\SQLEXPRESS;Initial Catalog=QLAPPDEMOBI-A2;Persist Security Info=True;User ID=SA;Password=123456";
            string query = "select * from KhachHangVip";
            using(SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
                DataTable tablekhachvip = new DataTable();
                adapter.Fill(tablekhachvip);
                dgvttkhachvip.DataSource = tablekhachvip;
            }
        }
        public khachhangvip()
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
                    string query = "insert into KhachHangVip(MaKhachHang,TenKhachHang,SoDienThoai,DiemTichLuy)values(@mkh,@tkh,@sdt,@diemvip)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@mkh", txtmakhachvip.Text);
                        command.Parameters.AddWithValue("@tkh", txttenkhachvip.Text);
                        command.Parameters.AddWithValue("@sdt", txtsovip.Text);
                        command.Parameters.AddWithValue("@diemvip", txtdiemvip.Text);
                        command.ExecuteNonQuery();
                        hienthikhachvip();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Loi:{ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hienthikhachvip();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ASUSROG\SQLEXPRESS;Initial Catalog=QLAPPDEMOBI-A2;Persist Security Info=True;User ID=SA;Password=123456"))
            {
                connection.Open();
                string query = "delete from KhachHangVip where MaKhachHang =@mkh";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mkh",txtmakhachvip.Text);
                    command.ExecuteNonQuery();
                    hienthikhachvip();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ASUSROG\SQLEXPRESS;Initial Catalog=QLAPPDEMOBI-A2;Persist Security Info=True;User ID=SA;Password=123456"))
            {
                connection.Open();
                string query = "update KhachHangVip set MaKhachHang = @mkh,TenKhachHang = @tkh,SoDienThoai = @sdt,DiemTichLuy=@diemtl";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mkh",txtmakhachvip.Text);
                    command.Parameters.AddWithValue("@tkh",txttenkhachvip.Text);
                    command.Parameters.AddWithValue("@sdt",txtsovip.Text);
                    command.Parameters.AddWithValue("@diemtl",txtdiemvip.Text);
                    command.ExecuteNonQuery();
                    hienthikhachvip();
                }
            }
        }

        private void dgvttkhachvip_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvttkhachvip.CurrentRow.Index;
            txtmakhachvip.Text = dgvttkhachvip.Rows[i].Cells[0].Value.ToString();
            txttenkhachvip.Text = dgvttkhachvip.Rows[i].Cells[1].Value.ToString();
            txtsovip.Text = dgvttkhachvip.Rows[i].Cells[2].Value.ToString();
            txtdiemvip.Text = dgvttkhachvip.Rows[i].Cells[3].Value.ToString();
        }
    }
}
