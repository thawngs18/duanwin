using iTextSharp.text.pdf.qrcode;
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
using WindowsFormsApp8.database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp8
{
    public partial class DangNhapTV : Form
    {
        public DangNhapTV()
        {
            InitializeComponent();
        }
        public event EventHandler CancelClicked;
        public event EventHandler OKClicked;


        private void btnThoat_Click(object sender, EventArgs e)
        {
            bool rs = false;
            BanVe frm = new BanVe(rs);
            CancelClicked?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenkh = txtTKTV.Text.Trim();
            string sdt = txt_sdt.Text.Trim();

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(tenkh) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập day du thong tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new Model1())
            {
                try
                {
                    // Tìm khách hàng có tên khớp
                    var khachHang = context.KhachHangs.FirstOrDefault(kh => kh.HoTen == tenkh && kh.SDT == sdt);

                    if (khachHang != null)
                    {
                        MessageBox.Show($"Xin chào KHTV: {khachHang.HoTen}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở form tiếp theo hoặc thực hiện hành động khác
                        this.Close(); // Ẩn form đăng nhập
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng thành viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
