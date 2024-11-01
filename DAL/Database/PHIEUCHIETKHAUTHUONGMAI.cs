namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUCHIETKHAUTHUONGMAI")]
    public partial class PHIEUCHIETKHAUTHUONGMAI
    {
        [Key]
        [StringLength(20)]
        public string MAPCKTM { get; set; }

        public DateTime NGAYINPHIEU { get; set; }

        public DateTime NGAYHETHAN { get; set; }

        public decimal GIATRITRIETKHAU { get; set; }

        [Required]
        [StringLength(20)]
        public string MANV { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
