namespace DBProvider1
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
        public string MaS { get; set; }

        [StringLength(200)]
        public string TenS { get; set; }

        [StringLength(10)]
        public string MaTG { get; set; }

        [StringLength(10)]
        public string MaTL { get; set; }

        [StringLength(10)]
        public string NXB { get; set; }

        public double? Gia { get; set; }

        public string ANH { get; set; }

        public double? GIAKM { get; set; }

        public virtual TACGIA TACGIA { get; set; }

        public virtual THELOAI THELOAI { get; set; }
    }
}
