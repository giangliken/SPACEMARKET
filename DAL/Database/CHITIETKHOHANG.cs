namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETKHOHANG")]
    public partial class CHITIETKHOHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string MASP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MAKHO { get; set; }

        public int SLTON { get; set; }

        public virtual KHOHANG KHOHANG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
