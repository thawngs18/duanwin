namespace WindowsFormsApp8.database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongChieu")]
    public partial class PhongChieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongChieu()
        {
            LichChieux = new HashSet<LichChieu>();
        }

        [StringLength(50)]
        public string id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenPhong { get; set; }

        [StringLength(50)]
        public string idManHinh { get; set; }

        public int SoChoNgoi { get; set; }

        public int TinhTrang { get; set; }

        public int SoHangGhe { get; set; }

        public int SoGheMotHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichChieu> LichChieux { get; set; }

        public virtual LoaiManHinh LoaiManHinh { get; set; }
    }
}
