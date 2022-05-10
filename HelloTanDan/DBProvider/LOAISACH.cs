namespace DBProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAISACH")]
    public partial class LOAISACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAISACH()
        {
            SACHes = new HashSet<SACH>();
        }

        [Key]
        [StringLength(10)]
        public string MAL { get; set; }

        [StringLength(50)]
        public string TENS { get; set; }

        [StringLength(30)]
        public string NHAXB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NAMXB { get; set; }

        public double? GIASACH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACH> SACHes { get; set; }
    }
}
