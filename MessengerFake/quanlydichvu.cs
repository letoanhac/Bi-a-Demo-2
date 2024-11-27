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
    public partial class quanlydichvu : Form
    {
        string connectionString = "Data Source=ASUSROG\\SQLEXPRESS;Initial Catalog=QLAPPDEMOBI-A2;Persist Security Info=True;User ID=SA;Password=123456";
        void hienthibangdichvu()
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select * from DichVu";
                SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
                DataTable tabledichvu = new DataTable();
                adapter.Fill(tabledichvu);
                dataGridView1.DataSource = tabledichvu;
            }
        }
        public quanlydichvu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal giaDichVu = 0;
            bool isNumeric = decimal.TryParse(txttiendv.Text, out giaDichVu);
            if (isNumeric)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO DichVu (MaDichVu, TenDichVu, GiaDichVu) VALUES (@mdv, @tdv, @gdv)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.Add("@mdv", SqlDbType.NVarChar, 50).Value = txtmadv.Text;
                    command.Parameters.Add("@tdv", SqlDbType.NVarChar, 100).Value = txttendv.Text;
                    command.Parameters.Add("@gdv", SqlDbType.Money).Value = giaDichVu;
                    command.ExecuteNonQuery();
                    hienthibangdichvu(); 
                }
            }
            else
            {
                MessageBox.Show("Giá dịch vụ không hợp lệ. Vui lòng nhập một giá trị số hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = " delete from DichVu where MaDichVu=@mdvu";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@mdvu", txtmadv.Text);
                command.ExecuteNonQuery();
                hienthibangdichvu();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "update DichVu set MaDichVu=@mdv,TenDichVu=@tdv,GiaDichVu=@gdv";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@mdv", txtmadv.Text);
                command.Parameters.AddWithValue("@tdv", txttendv.Text);
                command.Parameters.AddWithValue("@gdv", txttiendv.Text);
                command.ExecuteNonQuery();
                hienthibangdichvu();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtmadv.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txttendv.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txttiendv.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hienthibangdichvu();
        }
    }
}
