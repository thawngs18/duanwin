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
using System.Drawing.Imaging;
using System.Net.Mail;
using System.Net;
using System.IO;


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
            pnlQR.Visible = true;
            pnl_Email.Visible = false;
            QR qr = new QR(lblPhong.Text, lblTenPhim.Text, lblDate.Text, lblTenghe.Text);
            qr.MdiParent = this;
            pnlQR.Controls.Add(qr);
            qr.Show();
            toolStripButton1.Enabled = false;

        }

        private void Ve_Load_1(object sender, EventArgs e)
        {
            ResetLabelsInPanel();
            pnlQR.Visible=false;
            pnl_Email.Visible = false;
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
                ev.Graphics.DrawImage(qrImage, leftMargin + 112, topMargin + 230, 150, 150);
                int logoWidth = 50;
                int logoHeight = 50;

                try
                {
                    // Lấy logo từ Resources
                    Image logo = Properties.Resources.logo;

                    // Làm mờ logo
                    ImageAttributes imageAttr = new ImageAttributes();
                    ColorMatrix colorMatrix = new ColorMatrix
                    {
                        Matrix33 = 1.3f // Độ trong suốt
                    };
                    imageAttr.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    // Vẽ logo lặp lại trên toàn trang in
                    for (float y = 0; y < ev.PageBounds.Height; y += logoHeight + 10)
                    {
                        for (float x = 0; x < ev.PageBounds.Width; x += logoWidth + 10)
                        {
                            ev.Graphics.DrawImage(
                                logo,
                                new Rectangle((int)x, (int)y, logoWidth, logoHeight),
                                0, 0, logo.Width, logo.Height,
                                GraphicsUnit.Pixel,
                                imageAttr
                            );
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải logo: " + ex.Message);
                }
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pnlQR.Controls.Clear();
            pnlQR.Visible = false;
            pnl_Email.Visible = false;
            pnlVe.Visible = true;
            toolStripButton1.Enabled = true;
        }
        private string GenerateQRCodeBase64(string content)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            using (Bitmap qrImage = qrCode.GetGraphic(2))
            using (MemoryStream ms = new MemoryStream())
            {
                qrImage.Save(ms, ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            pnlQR.Controls.Clear();
            pnlQR.Visible = false;
            pnlVe.Visible = false;
            toolStripButton1.Enabled = true;
            pnl_Email.Visible = true;
        }

        private void btn_XN_Click(object sender, EventArgs e)
        {
            string fromEmail = "theunderdog0108@gmail.com"; // Email của bạn
            string appPassword = "leob pmdu aoyt oztl";  // Mật khẩu ứng dụng
            string toEmail = txt_mailnhan.Text; // Email người nhận
            string subject = "Đặt vé xem phim thành công!";

            // Nội dung vé
            string emailBody = string.Format(
            "Đây là thông tin vé xem phim của bạn!\n" +
            "==== Vé Xem Phim ====\n" +
            "Phim: {0}\n" +
            "Thời Gian Chiếu: {1}\n" +
            "Phòng Chiếu: {2}\n" +
            "Ghế: {3}\n" +
            "=====================\n",
                tenPhim, date, tenphong, tenghe);

            // Nội dung cho QR code (không có thông báo)
            string qrContent = string.Format(
                "==== Vé Xem Phim ====\n" +
                "Phim: {0}\n" +
                "Thời Gian Chiếu: {1}\n" +
                "Phòng Chiếu: {2}\n" +
                "Ghế: {3}\n" +
                "=====================\n",
                tenPhim, date, tenphong, tenghe);

            // Tạo mã QR
            string qrBase64 = GenerateQRCodeBase64(qrContent);

            // Tạo nội dung HTML cho email
            string bodyHtml = string.Format(
                "<html>" +
                "<body>" +
                "<p>{0}</p>" +
                "<p>Mã QR:</p>" +
                "<img src='data:image/png;base64,{1}' alt='QR Code'>" +
                "</body>" +
                "</html>",
                emailBody.Replace("\n", "<br>"), qrBase64);

            // Cấu hình SMTP
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, appPassword),
                EnableSsl = true,
            };

            // Tạo email
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = bodyHtml,
                IsBodyHtml = true, // Email dạng HTML
            };
            mailMessage.To.Add(toEmail);

            // Gửi email
            try
            {
                smtpClient.Send(mailMessage);
                MessageBox.Show("Email đã được gửi thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
            }
            pnl_Email.Visible = false;
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            Ve_Load_1(sender, e);
        }
    }
}
