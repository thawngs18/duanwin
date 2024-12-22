
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Documents;
using System.Windows.Forms;
using System;
using System.Drawing.Printing;



namespace WindowsFormsApp8
{
    public partial class BaoCao : Form
    {
        private PrintDocument printDoc;
        public BaoCao()
        {
            InitializeComponent();
            printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
           

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

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Tạo một Bitmap với kích thước của panel
            Bitmap bmp = new Bitmap(panelContent.Width, panelContent.Height);

            // Vẽ nội dung của panel lên Bitmap
            panelContent.DrawToBitmap(bmp, new Rectangle(0, 0, panelContent.Width, panelContent.Height));

            // Vẽ Bitmap lên trang in
            e.Graphics.DrawImage(bmp, e.MarginBounds);
        }


        // Khi tất c




        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolImage_Click(object sender, EventArgs e)
        {
            SaveFormAsImage();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // In trang
                printDoc.Print();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
