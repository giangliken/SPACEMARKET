namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LICHSUGIA")]
    public partial class LICHSUGIA
    {
        [Required]
        [StringLength(20)]
        public string MASP { get; set; }

        public decimal GIACU { get; set; }

        public decimal GIAMOI { get; set; }

        [Key]
        public DateTime NGAYTHAYDOI { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
