using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    public class BaoCaoItem
    {
        public int STT { get; set; } // Số thứ tự
        public string TenPhim { get; set; } // Tên phim
        public DateTime NgayChieu { get; set; } // Ngày chiếu
        public decimal TienBanVe { get; set; } // Doanh thu từ bán vé
    }
}
