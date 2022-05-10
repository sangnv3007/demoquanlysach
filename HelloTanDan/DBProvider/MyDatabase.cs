namespace DBProvider
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDatabase : DbContext
    {
        public MyDatabase()
            : base("name=MyDatabase")
        {
        }

        public virtual DbSet<LOAISACH> LOAISACHes { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LOAISACH>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.LOAISACH)
                .WillCascadeOnDelete(false);
        }
    }
}
