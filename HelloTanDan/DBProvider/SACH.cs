namespace DBProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [Key]
        [StringLength(10)]
        public string IDSACH { get; set; }

        [Required]
        [StringLength(10)]
        public string MAL { get; set; }

        [StringLength(10)]
        public string MAS { get; set; }

        public virtual LOAISACH LOAISACH { get; set; }
    }
}
