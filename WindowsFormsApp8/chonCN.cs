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
    public partial class chonCN : Form
    {
        public chonCN(string cn,string tendn)
        {
            InitializeComponent();
            button4.Text = tendn;
            label3.Text = cn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Seller s = new Seller();
            s.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin ad  = new admin();
            ad.ShowDialog();
        }

        private void chonCN_Load(object sender, EventArgs e)
        {
            if(label3.Text == "banve")
            {
                button1.Enabled = false;
            }

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap dangNhap = new DangNhap();
            dangNhap.ShowDialog();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Ban co chac muon doi lai mat khau","Canh bao",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                DatLaiMK doimk = new DatLaiMK(button4.Text);
                doimk.Show();
            }
            
        }
    }
}
