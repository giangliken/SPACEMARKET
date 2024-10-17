namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CHITIETHOADON = new HashSet<CHITIETHOADON>();
            PHIEUGIAOHANG = new HashSet<PHIEUGIAOHANG>();
            PHIEUQUATANG = new HashSet<PHIEUQUATANG>();
        }

        [Key]
        [StringLength(20)]
        public string MAHD { get; set; }

        [StringLength(20)]
        public string MANV { get; set; }

        [StringLength(20)]
        public string MAKH { get; set; }

        [StringLength(20)]
        public string PTTHANHTOAN { get; set; }

        public DateTime? NGAYLAP { get; set; }

        public decimal? THANHTIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADON { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUGIAOHANG> PHIEUGIAOHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUQUATANG> PHIEUQUATANG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
