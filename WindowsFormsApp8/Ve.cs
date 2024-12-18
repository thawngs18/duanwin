using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using QRCoder;

namespace WindowsFormsApp8
{
    public partial class Ve : Form
    {

        private string tenphong;
        private string tenPhim;
        private string date;
        private string tenghe;
        public Ve()
        {
            InitializeComponent();


        }
        public Ve(string tenphong, string tenPhim, string date, string tenghe)
        {
            InitializeComponent();
            this.tenphong = tenphong;
            this.tenPhim = tenPhim;
            this.date = date;
            this.tenghe = tenghe;
        }

        public void ResetLabelsInPanel()
        {
            // Duyệt qua tất cả các Control trong pnlVe
            foreach (Control control in pnlVe.Controls)
            {
                if (control is Label lbl)
                {
                    lbl.Text = ""; // Xóa nội dung của Label
                }
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            pnlVe.Visible = false;
            QR qr = new QR(lblPhong.Text, lblTenPhim.Text, lblDate.Text, lblTenghe.Text);
            qr.MdiParent = this;
            qr.Show();
        }

        private void Ve_Load_1(object sender, EventArgs e)
        {
            ResetLabelsInPanel();

            lblPhong.Text = tenphong;
            lblTenPhim.Text = tenPhim;
            lblDate.Text = date;
            lblTenghe.Text = tenghe;
        }

        private void toolbtnPrint_Click(object sender, EventArgs e)
        {
            // Nội dung vé xem phim cần in
            string noiDungVe = string.Format(
    "============= Ve Xem Phim =============\n" +
    "\n" +
    " {0,-22} : {1,-34}\n" +
    "\n" +
    " {2,-13} : {3,-34}\n" +
    "\n" +
    " {4,-16} : {5,-34}\n" +
    "\n" +
    "{6,-23} : {7,-34}\n" +
    "\n" +
    "=====================================" +
    "\n" +
    "\n" +
    "\n" +
    "\n" +
    "\n" +
    "\n" +
    "\n" +
    "\n" +
    "\n" +
    "\n" +
    "\n" +
    "=====================================",
    "Phim", tenPhim, "Thoi Gian Chieu", date, "Phong Chieu", tenphong, "Ghe ", tenghe);


            // Tạo PrintDocument và kết nối sự kiện PrintPage
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (s, ev) =>
            {
                // Vẽ nội dung văn bản lên trang in
                Font font = new Font("Arial", 12);
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                ev.Graphics.DrawString(noiDungVe, font, Brushes.Black, leftMargin, topMargin);

                // Nếu cần thêm hình ảnh (ví dụ: mã QR), có thể vẽ tại đây
                Bitmap qrImage = GenerateQRCode(noiDungVe);
                ev.Graphics.DrawImage(qrImage, leftMargin + 70, topMargin + 230, 150, 150);
            };

            // Hiển thị hộp thoại chọn máy in
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDoc
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Thực hiện lệnh in
                printDoc.Print();
            }
        }

        // Phương thức tạo mã QR từ nội dung
        private Bitmap GenerateQRCode(string content)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(2); // Tạo mã QR với kích thước 2x
        }
    }
}
