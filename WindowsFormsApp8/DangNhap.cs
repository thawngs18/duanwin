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

namespace WindowsFormsApp8
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = txt_user.Text.Trim();
            string password = txt_pass.Text.Trim();

            using (var context = new Model1())
            {
                // Tìm user trong cơ sở dữ liệu
                var user = context.ACCOUNTs
                    .FirstOrDefault(u => u.taikhoan == username && u.matkhau == password);

                if (user != null)
                {
                   
                    string idnv = user.idnv;
                    var cn = user.chucvu;
                    // Mở form chính hoặc thực hiện các hành động khác
                    this.Hide();
                    var name = context.NhanViens.FirstOrDefault(n => n.id == idnv);
                    var tendn = name.HoTen;
                    MessageBox.Show($"Đăng nhập thành công!,Xin chao {cn} : {tendn}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var cnfrom = new chonCN(cn, tendn); // Thay MainForm bằng form chính của bạn
                    cnfrom.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

    }
}
