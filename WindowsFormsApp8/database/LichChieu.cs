namespace WindowsFormsApp8.database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichChieu")]
    public partial class LichChieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LichChieu()
        {
            DoanhThus = new HashSet<DoanhThu>();
        }

        [StringLength(50)]
        public string id { get; set; }

        public DateTime ThoiGianChieu { get; set; }

        [Required]
        [StringLength(50)]
        public string idPhong { get; set; }

        [Required]
        [StringLength(50)]
        public string idDinhDang { get; set; }

        public decimal GiaVe { get; set; }

        public int TrangThai { get; set; }

        public virtual DinhDangPhim DinhDangPhim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoanhThu> DoanhThus { get; set; }

        public virtual PhongChieu PhongChieu { get; set; }
    }
}
