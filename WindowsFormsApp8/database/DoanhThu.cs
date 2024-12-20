namespace WindowsFormsApp8.database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoanhThu")]
    public partial class DoanhThu
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string idLichChieu { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string idPhim { get; set; }

        public double? Tien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayChieu { get; set; }

        public virtual LichChieu LichChieu { get; set; }

        public virtual Phim Phim { get; set; }
    }
}
