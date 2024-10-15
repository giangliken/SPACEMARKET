using System.Data.Entity;

namespace DAL.Database
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CHITIETKHOHANG> CHITIETKHOHANG { get; set; }
        public virtual DbSet<CHITIETHOADON> CHITIETHOADON { get; set; }
        public virtual DbSet<DANHMUC> DANHMUC { get; set; }
        public virtual DbSet<HOADON> HOADON { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<KHOHANG> KHOHANG { get; set; }
        public virtual DbSet<LICHSUGIA> LICHSUGIA { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAP { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<PHIEUGIAOHANG> PHIEUGIAOHANG { get; set; }
        public virtual DbSet<PHIEUQUATANG> PHIEUQUATANG { get; set; }
        public virtual DbSet<PHIEUTRIETKHAUTHUONGMAI> PHIEUTRIETKHAUTHUONGMAI { get; set; }
        public virtual DbSet<SANPHAM> SANPHAM { get; set; }
        public virtual DbSet<THETHANHVIEN> THETHANHVIEN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETKHOHANG>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETKHOHANG>()
                .Property(e => e.MAKHO)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.MAHD)
                .IsUnicode(false);

            modelBuilder.Entity<DANHMUC>()
                .Property(e => e.MADM)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAHD)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CHITIETHOADON)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.PHIEUGIAOHANG)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.PHIEUQUATANG)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDTKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.EMAILKH)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.HOADON)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHOHANG>()
                .Property(e => e.MAKHO)
                .IsUnicode(false);

            modelBuilder.Entity<KHOHANG>()
                .HasMany(e => e.CHITIETKHOHANG)
                .WithRequired(e => e.KHOHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LICHSUGIA>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<LICHSUGIA>()
                .Property(e => e.GIACU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LICHSUGIA>()
                .Property(e => e.GIAMOI)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MANCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SDTNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.EMAILNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.SANPHAM)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDTNV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.EMAILNV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.HOADON)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUTRIETKHAUTHUONGMAI)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUGIAOHANG>()
                .Property(e => e.MAPGH)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUGIAOHANG>()
                .Property(e => e.DIACHIGIAOHANG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUGIAOHANG>()
                .Property(e => e.SDTNGUOINHANHANG)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUGIAOHANG>()
                .Property(e => e.MAHD)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUQUATANG>()
                .Property(e => e.MAPQT)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUQUATANG>()
                .Property(e => e.PTGIAMGIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PHIEUQUATANG>()
                .Property(e => e.MAHD)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUTRIETKHAUTHUONGMAI>()
                .Property(e => e.MAPCKTM)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUTRIETKHAUTHUONGMAI>()
                .Property(e => e.GIATRITRIETKHAU)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PHIEUTRIETKHAUTHUONGMAI>()
                .Property(e => e.MANV)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MASP)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MANCC)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.MADM)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.GIABAN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETKHOHANG)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETHOADON)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THETHANHVIEN>()
                .Property(e => e.MATHE)
                .IsUnicode(false);

            modelBuilder.Entity<THETHANHVIEN>()
                .Property(e => e.DIEMTICHLUY)
                .HasPrecision(18, 0);

            modelBuilder.Entity<THETHANHVIEN>()
                .Property(e => e.MAKH)
                .IsUnicode(false);
        }
    }
}
