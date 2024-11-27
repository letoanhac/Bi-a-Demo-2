using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MessengerFake
{
    public partial class nhanvien : Form
    {
        void hienthinhanvien()
        {
            string str = @"Data Source=ASUSROG\SQLEXPRESS;Initial Catalog=QLAPPDEMOBI-A2;Persist Security Info=True;User ID=SA;Password=123456";
            string query = "select * from NhanVien";
            try
            {
                using(SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
                    DataTable tablenhanvien = new DataTable();
                    adapter.Fill(tablenhanvien);
                    dgvttnhanvien.DataSource = tablenhanvien;
                }
            }
            catch
            {
                MessageBox.Show("Loi");
            }
        }
        public nhanvien()
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
                    string query = "insert into NhanVien(TenNhanVien,QueQuan,Tuoi,Luong) values(@tennv,@quequannv,@tuoinv,@luongnv)";
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tennv",txttennv.Text);
                        command.Parameters.AddWithValue("@quequannv",txtquenv.Text);
                        command.Parameters.AddWithValue("@tuoinv",txttuoinv.Text);
                        command.Parameters.AddWithValue("@luongnv",txtluongnv.Text);
                        command.ExecuteNonQuery();
                        hienthinhanvien();
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("Ten nv k duoc trung", "Thong bao");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hienthinhanvien();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ASUSROG\SQLEXPRESS;Initial Catalog=QLAPPDEMOBI-A2;Persist Security Info=True;User ID=SA;Password=123456"))
            {
                connection.Open();
                string query = "delete from NhanVien where TenNhanVien =@tennv";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tennv", txttennv.Text);
                    command.ExecuteNonQuery();
                    hienthinhanvien();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=ASUSROG\SQLEXPRESS;Initial Catalog=QLAPPDEMOBI-A2;Persist Security Info=True;User ID=SA;Password=123456"))
            {
                connection.Open();
                string query = "update NhanVien set QueQuan = @qq,Tuoi=@tnv,Luong = @lnv where TenNhanVien = @tennv";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tennv",txttennv.Text);
                    command.Parameters.AddWithValue("@qq",txtquenv.Text);
                    command.Parameters.AddWithValue("@tnv",txttuoinv.Text);
                    command.Parameters.AddWithValue("@lnv",txtluongnv.Text);
                    int kiemtra = command.ExecuteNonQuery();
                    if (kiemtra > 0)
                    {
                        MessageBox.Show("Sua nv thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("Sua nv that bai");
                    }
                }
            }
        }

        private void dgvttnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvttnhanvien.CurrentRow.Index;
            txttennv.Text = dgvttnhanvien.Rows[i].Cells[0].Value.ToString();
            txtquenv.Text = dgvttnhanvien.Rows[i].Cells[1].Value.ToString();
            txttuoinv.Text = dgvttnhanvien.Rows[i].Cells[2].Value.ToString();
            txtluongnv.Text = dgvttnhanvien.Rows[i].Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
