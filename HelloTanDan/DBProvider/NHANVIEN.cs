namespace DBProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [Key]
        [StringLength(10)]
        public string IDNV { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        [StringLength(20)]
        public string HOTEN { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        public string PASSNV { get; set; }

        [StringLength(50)]
        public string DIACHI { get; set; }

        [StringLength(10)]
        public string QUYEN { get; set; }
    }
}
