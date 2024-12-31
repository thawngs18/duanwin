
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
using Microsoft.Reporting.WinForms;
using WindowsFormsApp8.database;



namespace WindowsFormsApp8
{
    public partial class BaoCao : Form
    {
        private Model1 Context;
        private List<DoanhThu> Items;
       
        public BaoCao()
        {
            InitializeComponent();
            Context = new Model1();
           
        }


        private void BaoCao_Load(object sender, EventArgs e)
        {
            var Query = from bc in Context.DoanhThus
                        join db in Context.Phims on bc.idPhim equals db.id
                        select new
                        {
                            Phim = db.TenPhim,
                            NgayChieu = db.NgayKhoiChieu,
                            Tien = bc.Tien
                        };

           

            var reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = Query.ToList();
            this.reportViewer1.LocalReport.DataSources.Clear(); // xóa dữ liệu cũ
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
