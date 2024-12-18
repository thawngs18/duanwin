namespace WindowsFormsApp8.database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phim")]
    public partial class Phim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phim()
        {
            DinhDangPhims = new HashSet<DinhDangPhim>();
            DoanhThus = new HashSet<DoanhThu>();
            TheLoais = new HashSet<TheLoai>();
        }

        [StringLength(50)]
        public string id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenPhim { get; set; }

        [StringLength(1000)]
        public string MoTa { get; set; }

        public double ThoiLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKhoiChieu { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKetThuc { get; set; }

        [Required]
        [StringLength(50)]
        public string SanXuat { get; set; }

        [StringLength(100)]
        public string DaoDien { get; set; }

        public int NamSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DinhDangPhim> DinhDangPhims { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoanhThu> DoanhThus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheLoai> TheLoais { get; set; }
    }
}
