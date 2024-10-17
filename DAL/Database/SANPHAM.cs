namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETKHOHANG = new HashSet<CHITIETKHOHANG>();
            CHITIETHOADON = new HashSet<CHITIETHOADON>();
            LICHSUGIA = new HashSet<LICHSUGIA>();
        }

        [Key]
        [StringLength(20)]
        public string MASP { get; set; }

        [Required]
        [StringLength(20)]
        public string MANCC { get; set; }

        [Required]
        [StringLength(20)]
        public string MADM { get; set; }

        [Required]
        [StringLength(100)]
        public string TENSP { get; set; }

        public decimal GIABAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETKHOHANG> CHITIETKHOHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADON { get; set; }

        public virtual DANHMUC DANHMUC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICHSUGIA> LICHSUGIA { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
