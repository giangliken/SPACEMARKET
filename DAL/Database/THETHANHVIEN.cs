namespace DAL.Database
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("THETHANHVIEN")]
    public partial class THETHANHVIEN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MATHE { get; set; }

        public DateTime NGAYCAP { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime HANSUDUNG { get; set; }

        public decimal DIEMTICHLUY { get; set; }

        [Required]
        [StringLength(20)]
        public string BACTHE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MAKH { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}