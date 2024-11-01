namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUQUATANG")]
    public partial class PHIEUQUATANG
    {
        [Key]
        [StringLength(20)]
        public string MAPQT { get; set; }

        public decimal PTGIAMGIA { get; set; }

        public DateTime THOIGIANBATDAU { get; set; }

        public DateTime THOIGIANKETTHUC { get; set; }

        [StringLength(50)]
        public string DIEUKIENAPDUNG { get; set; }

        [StringLength(50)]
        public string MOTA { get; set; }

        [Required]
        [StringLength(20)]
        public string MAHD { get; set; }

        public virtual HOADON HOADON { get; set; }
    }
}
