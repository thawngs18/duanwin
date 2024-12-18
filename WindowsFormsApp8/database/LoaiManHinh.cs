namespace WindowsFormsApp8.database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiManHinh")]
    public partial class LoaiManHinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiManHinh()
        {
            DinhDangPhims = new HashSet<DinhDangPhim>();
            PhongChieux = new HashSet<PhongChieu>();
        }

        [StringLength(50)]
        public string id { get; set; }

        [StringLength(100)]
        public string TenMH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DinhDangPhim> DinhDangPhims { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhongChieu> PhongChieux { get; set; }
    }
}
