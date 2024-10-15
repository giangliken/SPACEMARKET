namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            HOADON = new HashSet<HOADON>();
            THETHANHVIEN = new HashSet<THETHANHVIEN>();
        }

        [Key]
        [StringLength(20)]
        public string MAKH { get; set; }

        [Required]
        [StringLength(100)]
        public string TENKH { get; set; }

        public DateTime NGAYSINH { get; set; }

        [Required]
        [StringLength(20)]
        public string CCCD { get; set; }

        [Required]
        [StringLength(200)]
        public string DIACHI { get; set; }

        [Required]
        [StringLength(20)]
        public string SDTKH { get; set; }

        [StringLength(200)]
        public string EMAILKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THETHANHVIEN> THETHANHVIEN { get; set; }
    }
}
