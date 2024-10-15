namespace DAL.Database
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KHOHANG")]
    public partial class KHOHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHOHANG()
        {
            CHITIETKHOHANG = new HashSet<CHITIETKHOHANG>();
        }

        [Key]
        [StringLength(20)]
        public string MAKHO { get; set; }

        [Required]
        [StringLength(100)]
        public string TENKHO { get; set; }

        [Required]
        [StringLength(200)]
        public string DIACHIKHO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETKHOHANG> CHITIETKHOHANG { get; set; }
    }
}
