namespace DAL.Database
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CHITIETHOADON")]
    public partial class CHITIETHOADON
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MASP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MAHD { get; set; }

        public int SOLUONG { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
