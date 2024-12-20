using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp8.database;

namespace WindowsFormsApp8
{
    public partial class Seller : Form
    {
        public Seller()
        {
            InitializeComponent();
        }
        
        private void Seller_Load(object sender, EventArgs e)
        {
            using (var context = new Model1())
            {
                var phimList = context.Phims
                    .Select(p => new
                    {
                        p.id,
                        p.TenPhim
                    })
                    .ToList();

                comboBox1.DisplayMember = "TenPhim";
                comboBox1.ValueMember = "id";
                comboBox1.DataSource = phimList;

                var loaiManHinhList = context.LoaiManHinhs
                    .Select(lmh => new
                    {
                        lmh.id,
                        lmh.TenMH
                    })
                    .ToList();

                comboBox2.DisplayMember = "TenMH";
                comboBox2.ValueMember = "id";
                comboBox2.DataSource = loaiManHinhList;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenP = comboBox1.Text.Trim(); // Tên phim được chọn
            string tenMH = comboBox2.Text.Trim(); // Tên loại màn hình được chọn
            DateTime ngayChon = dtpThoiGianChieu.Value; // Ngày được chọn trong DateTimePicker
            int thangChon = ngayChon.Month; // Lấy tháng từ ngày
            int namChon = ngayChon.Year;   // Lấy năm từ ngày

            try
            {
                using (var context = new Model1())
                {
                    var result = (from l in context.LichChieux
                                  join d in context.DinhDangPhims on l.idDinhDang equals d.id
                                  join p in context.Phims on d.idPhim equals p.id
                                  join h in context.LoaiManHinhs on d.idLoaiManHinh equals h.id
                                  join c in context.PhongChieux on l.idPhong equals c.id
                                  where p.TenPhim == tenP
                                        && h.TenMH == tenMH
                                        && SqlFunctions.DatePart("month", l.ThoiGianChieu) == thangChon
                                        && SqlFunctions.DatePart("year", l.ThoiGianChieu) == namChon
                                  select new
                                  {
                                      l.id,
                                      p.TenPhim,
                                      h.TenMH,
                                      l.ThoiGianChieu,
                                      p.ThoiLuong,
                                      c.SoChoNgoi,
                                      c.TenPhong
                                  }).ToList();

                    // Hiển thị dữ liệu trong DataGridView
                    dtgLichChieuP.DataSource = result;

                    // Thông báo nếu không có kết quả
                    if (!result.Any())
                    {
                        MessageBox.Show("Không có lịch chiếu nào khớp với tháng đã chọn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        string idlc = "";
        string tenphim = "";
        string tenmh = "";
        string time = "";
        string tenphong = "";
        private void dtgLichChieuP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgLichChieuP.SelectedRows.Count > 0) // Kiểm tra xem có hàng nào được chọn không
            {
                var row = dtgLichChieuP.SelectedRows[0];
                idlc = row.Cells["id"].Value?.ToString();
                tenphim = row.Cells["TenPhim"].Value?.ToString();
                tenmh = row.Cells["TenMH"].Value?.ToString();
                time = row.Cells["ThoiGianChieu"].Value?.ToString();
                tenphong = row.Cells["TenPhong"].Value?.ToString();


            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            BanVe bv = new BanVe(idlc, tenphong, tenphim, tenmh, time);
            bv.Show();
        }


    }
}
