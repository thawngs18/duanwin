﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
    

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Text = "Doanh Thu";
            pnlDoanhThu.Visible = true;
            pnlKhachHang.Visible = false;
            pnlNhanVien.Visible = false;
            panel1.Visible = false;
        }

    

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Text = "Khach Hang";
            pnlKhachHang.Visible = true;
            pnlNhanVien.Visible = false;
            pnlDoanhThu.Visible = false;
            panel1.Visible = false;

        }

        private void admin_Load(object sender, EventArgs e)
        {
            pnlDoanhThu.Visible = false;
            pnlKhachHang.Visible = false;
            pnlNhanVien.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            grpDuLieu.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Text = "Nhan Vien";
            pnlNhanVien.Visible = true;
            pnlDoanhThu.Visible = false;
            pnlKhachHang.Visible = false;
            
        }


        private void button18_Click(object sender, EventArgs e)
        {
            this.Text = "Loai Man Hinh";
            pnlLoaiManHinh.Visible = true;
            pnlDoanhThu.Visible = false;
            pnlKhachHang.Visible = false;
            pnlNhanVien.Visible = false;
            panel1.Visible = true;
            panel2.Visible = true;
            grpDuLieu.Visible = true;
            pnlPhongChieu.Visible = false;

            
 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Text = "Du Lieu";
            panel1.Visible = true;
            pnlNhanVien.Visible = false;
            pnlDoanhThu.Visible = false;
            pnlKhachHang.Visible = false;
            panel1.Visible = true;
            panel2.Visible = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.Text = "Phong Chieu";
            pnlDoanhThu.Visible = false;
            pnlKhachHang.Visible = false;
            pnlNhanVien.Visible = false;
            panel1.Visible = true;
            panel2.Visible = true;
            grpDuLieu.Visible = true;
            pnlPhongChieu.Visible = true;
            pnlLoaiManHinh.Visible = false;


        }
    }
}
