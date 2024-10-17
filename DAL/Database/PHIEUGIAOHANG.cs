namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUGIAOHANG")]
    public partial class PHIEUGIAOHANG
    {
        [Key]
        [StringLength(20)]
        public string MAPGH { get; set; }

        public DateTime NGAYDUKIENGH { get; set; }

        [Required]
        [StringLength(200)]
        public string DIACHIGIAOHANG { get; set; }

        [Required]
        [StringLength(20)]
        public string SDTNGUOINHANHANG { get; set; }

        [StringLength(200)]
        public string MOTA { get; set; }

        [Required]
        [StringLength(20)]
        public string MAHD { get; set; }

        public virtual HOADON HOADON { get; set; }
    }
}
