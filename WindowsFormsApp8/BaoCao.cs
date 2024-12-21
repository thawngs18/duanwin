using System;
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
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
           
        }
      
        // Phương thức hiển thị báo cáo
        public void HienThiBaoCao(List<BaoCaoItem> danhSachBaoCao, decimal tongDoanhThu, DateTime tuNgay, DateTime denNgay)
        {

            dgvBaoCaoDT.Rows.Clear();

            // Thêm dữ liệu mới
            foreach (var item in danhSachBaoCao)
            {
                dgvBaoCaoDT.Rows.Add(item.STT, item.TenPhim, item.NgayChieu.ToString("dd/MM/yyyy HH:mm"), item.TienBanVe.ToString("C"));
            }

            // Hiển thị tổng doanh thu
            txtDoanhThu.Text = tongDoanhThu.ToString("C");

            // Hiển thị khoảng thời gian "Từ ngày" và "Đến ngày"
            txtNgayBD.Text = tuNgay.ToString("dd/MM/yyyy");
            txtNgayKT.Text = denNgay.ToString("dd/MM/yyyy");

            // Hiển thị ngày giờ báo cáo
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
