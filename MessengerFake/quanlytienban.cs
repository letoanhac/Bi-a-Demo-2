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
using static MessengerFake.quanlytienban;

namespace MessengerFake
{
    public partial class quanlytienban : Form
    {
        private int invoiceNumber = 1;
        private string connectionString = "Data Source=ASUSROG\\SQLEXPRESS;Initial Catalog=QLAPPDEMOBI-A2;Persist Security Info=True;User ID=SA;Password=123456";
        private Dictionary<Button, Ban> danhSachBan = new Dictionary<Button, Ban>();
        public class Ban
        {
            private int invoiceNumber = 1;
            public string MaBan { get; set; } // Mã bàn ( "Bàn 1")
            public string TrangThai { get; set; } // Trạng thái bàn (Trống/Hoạt động)
            public DateTime? GioBatDau { get; set; } // Thời gian bật bàn
            public DateTime? GioKetThuc { get; set; } // Thời gian tắt bàn
            public decimal? TienBan { get; set; } // Số tiền bàn
            public string MaHoaDon { get; set; } // Mã hóa đơn duy nhất
        }
        private void khoiTaoDanhSachBan()
        {
            danhSachBan.Add(button1, new Ban { MaBan = "Bàn 1", TrangThai = "Trống" });
            danhSachBan.Add(button2, new Ban { MaBan = "Bàn 2", TrangThai = "Trống" });
            danhSachBan.Add(button3, new Ban { MaBan = "Bàn 3", TrangThai = "Trống" });
            danhSachBan.Add(button4, new Ban { MaBan = "Bàn 4", TrangThai = "Trống" });
            danhSachBan.Add(button5, new Ban { MaBan = "Bàn 5", TrangThai = "Trống" });
            danhSachBan.Add(button6, new Ban { MaBan = "Bàn 6", TrangThai = "Trống" });
            danhSachBan.Add(button7, new Ban { MaBan = "Bàn 7", TrangThai = "Trống" });
            danhSachBan.Add(button8, new Ban { MaBan = "Bàn 8", TrangThai = "Trống" });
            danhSachBan.Add(button9, new Ban { MaBan = "Bàn 9", TrangThai = "Trống" });
            danhSachBan.Add(button11, new Ban { MaBan = "Bàn 10", TrangThai = "Trống" });
            danhSachBan.Add(button12, new Ban { MaBan = "Bàn 11", TrangThai = "Trống" });
            danhSachBan.Add(button13, new Ban { MaBan = "Bàn 12", TrangThai = "Trống" });
        }
        public quanlytienban()
        {
            InitializeComponent();
            khoiTaoDanhSachBan();
        }
        void hienthihamthanhtien()
        {

        }
        private void hienthitungban()
        {
            groupBox2.Visible = true;
        }
        /*public void kiemtramauban(Button a)
        {
            // Kiểm tra nếu bàn đang tắt (màu xanh)
            if (a.BackColor == Color.Lime)
            {
                a.BackColor = Color.Red; // Đổi sang màu đỏ (bàn đang bật)
                a.Enabled = true; // Cho phép bấm lại để thay đổi trạng thái
            }
            else
            {
                MessageBox.Show("Bàn này đã được bật!", "Thông báo");
            }
        }
        public void kiemtrabantat(Button b)
        {
            if (b.BackColor == Color.Red)
            {
                b.BackColor = Color.Lime; // Đổi sang màu xanh (bàn tắt)
                b.Enabled = true; // Cho phép bấm lại để thay đổi trạng thái
            }
            else
            {
                MessageBox.Show("Bàn này đang tắt!", "Thông báo");
            }
        }*/
        private void hienThiThongTinBan(Button button)
        {
            if (danhSachBan.ContainsKey(button))
            {
                var ban = danhSachBan[button];
                lblmaban.Text = ban.MaBan;
                lbltrangthai.Text = ban.TrangThai;
                lblbatban.Text = ban.GioBatDau?.ToString("HH:mm:ss") ?? "Chưa bật";
                lbltatban.Text = ban.GioKetThuc?.ToString("HH:mm:ss") ?? "Chưa tắt";
                lbltienban.Text = ban.TienBan?.ToString("NO") ?? "0";
                hienthitungban();
            }
        }
        private string GenerateRandomInvoiceCode()
        {
            string newInvoiceCode = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TOP 1 MaHoaDon FROM SuDungBan ORDER BY MaHoaDon DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        // Lấy mã hóa đơn cuối cùng, tăng thêm 1
                        string lastInvoiceCode = result.ToString(); // Ví dụ: "HD000001"
                        int numericPart = int.Parse(lastInvoiceCode.Substring(2)); // Bỏ phần "HD"
                        newInvoiceCode = "HD" + (numericPart + 1).ToString("D6");
                    }
                    else
                    {
                        // Nếu không có hóa đơn nào, bắt đầu từ HD000001
                        newInvoiceCode = "HD000001";
                    }
                }
            }
            return newInvoiceCode;
        }//ham dua ra ma hoa don +1

        private void button14_Click(object sender, EventArgs e)
        {
            var maban = lblmaban.Text;
            foreach (var kvp in danhSachBan)
            {
                if (kvp.Value.MaBan == maban && kvp.Value.TrangThai == "Trống")
                {
                    kvp.Value.TrangThai = "HOẠT ĐỘNG";
                    kvp.Value.GioBatDau = DateTime.Now;
                    kvp.Value.MaHoaDon = GenerateRandomInvoiceCode();
                    kvp.Key.BackColor = Color.Red;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO SuDungBan (MaHoaDon, ThoiGianBat, TienBan) VALUES (@MaHoaDon, @ThoiGianBat, @TienBan)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MaHoaDon", kvp.Value.MaHoaDon);
                            command.Parameters.AddWithValue("@ThoiGianBat", kvp.Value.GioBatDau);
                            command.Parameters.AddWithValue("@TienBan", 0);
                            command.ExecuteNonQuery();
                        }
                    }

                    hienThiThongTinBan(kvp.Key);
                    break;
                }
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            hienThiThongTinBan(button1);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var maban = lblmaban.Text;
            foreach (var kvp in danhSachBan)
            {
                if (kvp.Value.MaBan == maban && kvp.Value.TrangThai == "HOẠT ĐỘNG")
                {
                    kvp.Value.TrangThai = "Trống";
                    kvp.Value.GioKetThuc = DateTime.Now;
                    kvp.Key.BackColor = Color.Lime;

                    if (kvp.Value.GioBatDau.HasValue && kvp.Value.GioKetThuc.HasValue)
                    {
                        TimeSpan thoiGianSuDung = kvp.Value.GioKetThuc.Value - kvp.Value.GioBatDau.Value;
                        decimal giaMoiGio = 50000; // Giá 50,000 VNĐ/giờ
                        decimal tienBan = Math.Round((decimal)thoiGianSuDung.TotalHours * giaMoiGio, 0);
                        kvp.Value.TienBan = tienBan;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "UPDATE SuDungBan SET ThoiGianTat = @ThoiGianTat, TienBan = @TienBan WHERE MaHoaDon = @MaHoaDon";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ThoiGianTat", kvp.Value.GioKetThuc);
                                command.Parameters.AddWithValue("@TienBan", tienBan);
                                command.Parameters.AddWithValue("@MaHoaDon", kvp.Value.MaHoaDon);
                                command.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show($"Tiền bàn cho {maban}: {tienBan:N0} VNĐ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    hienThiThongTinBan(kvp.Key);
                    break;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hienThiThongTinBan(button11);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hienThiThongTinBan(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hienThiThongTinBan(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hienThiThongTinBan(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hienThiThongTinBan(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hienThiThongTinBan(button6);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hienThiThongTinBan(button12);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hienThiThongTinBan(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hienThiThongTinBan(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hienThiThongTinBan(button9);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            hienThiThongTinBan(button13);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            dichvuthem f = new dichvuthem();
            f.Show();
        }

        private void lbltienban_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }
        }
    }
}
