using Microsoft.EntityFrameworkCore;
using StockManager.AdministrationContext.Infra.Data.Entities;
using StockManager.Infra.Multitenancy;
using System.Linq;

namespace StockManager.AdministrationContext.Infra.Data
{
    public class AdministrationDbContext : DbContext
    {
        private Tenant _tenant;

        public DbSet<ProductTable> Products { get; set; }

        public AdministrationDbContext(
            DbContextOptions<AdministrationDbContext> options,
            Tenant tenant) : base(options)
        {
            _tenant = tenant;

            var created = Database.EnsureCreated();

            if (!created)
                Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_tenant.ConnStr);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTable>(entity =>
            {
                entity.HasKey(y => y.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
