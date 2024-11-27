using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessengerFake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kHÁCHHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            khachhang f = new khachhang();
            f.ShowDialog();
        }

        private void NHANVIENTOOLMENU_Click(object sender, EventArgs e)
        {
            nhanvien f = new nhanvien();
            f.ShowDialog();
        }

        private void kHÁCHHÀNGVIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            khachhangvip f = new khachhangvip();
            f.ShowDialog();
        }

        private void qUẢNLÝCHUNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void qUẢNLÝTIỀNBÀNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlytienban f = new quanlytienban();
            f.Show();
        }

        private void qUẢNLÝHÓAĐƠNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlyhoadon f = new quanlyhoadon();
            f.ShowDialog();
        }

        private void tHÊMDỊCHVỤKHÁCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlydichvu f = new quanlydichvu();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLCHUNGMENU.Enabled = true;
            KHACHHANGMENU.Enabled = true;
            NHANVIENMENU.Enabled = false;
            KHACHHANGVIPMENU.Enabled = true;
            QUANLYTIENBANMENU.Enabled = true;
            QUANLYHOADONMENU.Enabled = true;
            THEMDICHVUKHACMENU.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QLCHUNGMENU.Enabled = false;
            KHACHHANGMENU.Enabled = false;
            NHANVIENMENU.Enabled = false;
            KHACHHANGVIPMENU.Enabled = false;
            QUANLYTIENBANMENU.Enabled = false;
            QUANLYHOADONMENU.Enabled = false;
            THEMDICHVUKHACMENU.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QLCHUNGMENU.Enabled = true;
            KHACHHANGMENU.Enabled = true;
            NHANVIENMENU.Enabled = true;
            KHACHHANGVIPMENU.Enabled = true;
            QUANLYTIENBANMENU.Enabled = true;
            QUANLYHOADONMENU.Enabled = true;
            THEMDICHVUKHACMENU.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            QLCHUNGMENU.Enabled = false;
            KHACHHANGMENU.Enabled = false;
            NHANVIENMENU.Enabled = false;
            KHACHHANGVIPMENU.Enabled = false;
            QUANLYTIENBANMENU.Enabled = false;
            QUANLYHOADONMENU.Enabled = false;
            THEMDICHVUKHACMENU.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
