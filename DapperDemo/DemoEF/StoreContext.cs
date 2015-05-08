using DapperModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DemoEF
{
    public class StoreContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public StoreContext()
            : base("CurrentDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("store");

            modelBuilder.Entity<Category>().Property(p => p.Code).IsRequired();
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithRequired(p => p.Category);

            base.OnModelCreating(modelBuilder);
        }
    }
}
