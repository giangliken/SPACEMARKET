namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYENHAN")]
    public partial class QUYENHAN
    {
        [Key]
        [StringLength(10)]
        public string MAQUYENHAN { get; set; }

        [Required]
        [StringLength(100)]
        public string TENQUYENHAN { get; set; }

        public string GHICHU { get; set; }
    }
}
