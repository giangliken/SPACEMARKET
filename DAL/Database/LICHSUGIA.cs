namespace DAL.Database
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
