namespace WindowsFormsApp8.database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DinhDangPhim")]
    public partial class DinhDangPhim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DinhDangPhim()
        {
            LichChieux = new HashSet<LichChieu>();
        }

        [StringLength(50)]
        public string id { get; set; }

        [Required]
        [StringLength(50)]
        public string idPhim { get; set; }

        [Required]
        [StringLength(50)]
        public string idLoaiManHinh { get; set; }

        public virtual LoaiManHinh LoaiManHinh { get; set; }

        public virtual Phim Phim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichChieu> LichChieux { get; set; }
    }
}
