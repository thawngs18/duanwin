using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
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
        private void SaveFormAsImage()
        {
            try
            {
                // Đảm bảo kích thước Bitmap khớp với nội dung của Panel
                int width = panelContent.Width;
                int height = panelContent.Height;

                // Kiểm tra nếu nội dung lớn hơn kích thước hiện tại của Panel
                if (panelContent.PreferredSize.Height > height)
                {
                    height = panelContent.PreferredSize.Height;
                }
                if (panelContent.PreferredSize.Width > width)
                {
                    width = panelContent.PreferredSize.Width;
                }

                // Tạo Bitmap với kích thước phù hợp
                Bitmap bitmap = new Bitmap(width, height);

                // Vẽ nội dung của Panel lên Bitmap
                panelContent.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, width, height));

                // Hiển thị SaveFileDialog để người dùng chọn nơi lưu
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp",
                    Title = "Save the Report as Image"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Lưu ảnh vào file
                    bitmap.Save(sfd.FileName);
                    MessageBox.Show("Saved as image successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving content as image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolImage_Click(object sender, EventArgs e)
        {
            SaveFormAsImage();
        }


    }
}
