namespace BlendSlideShow
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LocalDbContext : DbContext
    {
        public LocalDbContext()
            : base("name=LocalTest")
        {
        }

        public virtual DbSet<MyData> MyDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
