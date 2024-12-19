using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp8.database
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            this.Configuration.LazyLoadingEnabled = false; // T?t Lazy Loading
        }

        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<DinhDangPhim> DinhDangPhims { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LichChieu> LichChieux { get; set; }
        public virtual DbSet<LoaiManHinh> LoaiManHinhs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phim> Phims { get; set; }
        public virtual DbSet<PhongChieu> PhongChieux { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<DoanhThu> DoanhThus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.idnv)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.chucvu)
                .IsUnicode(false);

            modelBuilder.Entity<DinhDangPhim>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<DinhDangPhim>()
                .Property(e => e.idPhim)
                .IsUnicode(false);

            modelBuilder.Entity<DinhDangPhim>()
                .Property(e => e.idLoaiManHinh)
                .IsUnicode(false);

            modelBuilder.Entity<DinhDangPhim>()
                .HasMany(e => e.LichChieux)
                .WithRequired(e => e.DinhDangPhim)
                .HasForeignKey(e => e.idDinhDang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<LichChieu>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<LichChieu>()
                .Property(e => e.idPhong)
                .IsUnicode(false);

            modelBuilder.Entity<LichChieu>()
                .Property(e => e.idDinhDang)
                .IsUnicode(false);

            modelBuilder.Entity<LichChieu>()
                .HasMany(e => e.DoanhThus)
                .WithRequired(e => e.LichChieu)
                .HasForeignKey(e => e.idLichChieu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiManHinh>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiManHinh>()
                .HasMany(e => e.DinhDangPhims)
                .WithRequired(e => e.LoaiManHinh)
                .HasForeignKey(e => e.idLoaiManHinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiManHinh>()
                .HasMany(e => e.PhongChieux)
                .WithOptional(e => e.LoaiManHinh)
                .HasForeignKey(e => e.idManHinh);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ACCOUNTs)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.idnv);

            modelBuilder.Entity<Phim>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Phim>()
                .HasMany(e => e.DinhDangPhims)
                .WithRequired(e => e.Phim)
                .HasForeignKey(e => e.idPhim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phim>()
                .HasMany(e => e.DoanhThus)
                .WithRequired(e => e.Phim)
                .HasForeignKey(e => e.idPhim)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phim>()
                .HasMany(e => e.TheLoais)
                .WithMany(e => e.Phims)
                .Map(m => m.ToTable("PhanLoaiPhim").MapLeftKey("idPhim").MapRightKey("idTheLoai"));

            modelBuilder.Entity<PhongChieu>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<PhongChieu>()
                .Property(e => e.idManHinh)
                .IsUnicode(false);

            modelBuilder.Entity<PhongChieu>()
                .HasMany(e => e.LichChieux)
                .WithRequired(e => e.PhongChieu)
                .HasForeignKey(e => e.idPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheLoai>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<DoanhThu>()
                .Property(e => e.idLichChieu)
                .IsUnicode(false);

            modelBuilder.Entity<DoanhThu>()
                .Property(e => e.idPhim)
                .IsUnicode(false);
        }
    }
}
