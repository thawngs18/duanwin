namespace WindowsFormsApp8.database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNT")]
    public partial class ACCOUNT
    {
        [StringLength(10)]
        public string id { get; set; }

        [StringLength(50)]
        public string idnv { get; set; }

        [StringLength(50)]
        public string taikhoan { get; set; }

        [StringLength(50)]
        public string matkhau { get; set; }

        [StringLength(50)]
        public string chucvu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
