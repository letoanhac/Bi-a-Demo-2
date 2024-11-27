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
    public partial class dichvuthem : Form
    {
        private decimal tongTien = 0;
        string connectionStr = "Data Source=ASUSROG\\SQLEXPRESS;Initial Catalog=QLAPPDEMOBI-A2;Persist Security Info=True;User ID=SA;Password=123456";
        void hienthichondichvu()
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select * from DichVuThanhToan";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable tabledichvu2 = new DataTable();
                adapter.Fill(tabledichvu2);
                dataGridView2.DataSource = tabledichvu2;
            }
        }
        public dichvuthem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string query = "select * from DichVu";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable tabledichvu1 = new DataTable();
                adapter.Fill(tabledichvu1);
                dataGridView1.DataSource = tabledichvu1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string maDichVu = txtnhapmadv.Text.Trim();

            if (!string.IsNullOrEmpty(maDichVu))
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string querySelect = "SELECT * FROM DichVu WHERE MaDichVu = @MaDichVu";
                    using (SqlCommand commandSelect = new SqlCommand(querySelect, connection))
                    {
                        commandSelect.Parameters.AddWithValue("@MaDichVu", maDichVu);

                        using (SqlDataReader reader = commandSelect.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string tenDichVu = reader["TenDichVu"].ToString();
                                decimal giaDichVu = Convert.ToDecimal(reader["GiaDichVu"]);

                                // Thêm dữ liệu vào DataGridView
                                dataGridView2.Rows.Add(maDichVu, tenDichVu, giaDichVu);

                                // Cộng giá dịch vụ vào tổng tiền
                                tongTien += giaDichVu;

                                // Hiển thị tổng tiền lên TextBox hoặc Label
                                label4.Text = tongTien.ToString("N0");
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy mã dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string maDichVu = txtnhapmadv.Text.Trim();

            if (!string.IsNullOrEmpty(maDichVu))
            {
                bool found = false;

                // Duyệt qua các hàng trong DataGridView để tìm hàng có mã dịch vụ khớp
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells["Column1"].Value != null && row.Cells["Column1"].Value.ToString() == maDichVu)
                    {
                        // Lấy giá trị GiáDichVu từ hàng
                        decimal giaDichVu = Convert.ToDecimal(row.Cells["Column3"].Value);

                        // Trừ giá trị này khỏi tổng tiền
                        tongTien -= giaDichVu;

                        // Xóa hàng khỏi DataGridView
                        dataGridView2.Rows.Remove(row);

                        // Đánh dấu là đã tìm thấy và xóa
                        found = true;
                        break; // Thoát khỏi vòng lặp sau khi xóa
                    }
                }

                // Cập nhật tổng tiền hiển thị
                label4.Text = tongTien.ToString("N0");

                // Nếu không tìm thấy mã dịch vụ trong DataGridView
                if (!found)
                {
                    MessageBox.Show("Không tìm thấy mã dịch vụ trong danh sách hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã dịch vụ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void tongtientatca()
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtnhapmadv.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtnhaptendv.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtgiadichvua.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }
    }
}
