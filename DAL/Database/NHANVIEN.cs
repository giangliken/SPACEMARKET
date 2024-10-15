namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HOADON = new HashSet<HOADON>();
            PHIEUTRIETKHAUTHUONGMAI = new HashSet<PHIEUTRIETKHAUTHUONGMAI>();
        }

        [Key]
        [StringLength(20)]
        public string MANV { get; set; }

        [Required]
        [StringLength(100)]
        public string TENNV { get; set; }

        [Required]
        [StringLength(20)]
        public string CCCD { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime NGAYSINH { get; set; }

        [Required]
        [StringLength(50)]
        public string CV { get; set; }

        [Required]
        [StringLength(20)]
        public string SDTNV { get; set; }

        [StringLength(200)]
        public string EMAILNV { get; set; }

        [Required]
        [StringLength(50)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(50)]
        public string PASSWORD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTRIETKHAUTHUONGMAI> PHIEUTRIETKHAUTHUONGMAI { get; set; }
    }
}
