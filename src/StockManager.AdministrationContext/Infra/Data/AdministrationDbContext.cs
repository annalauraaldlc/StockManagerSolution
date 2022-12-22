using StockManager.AdministrationContext.Infra.Data.Entities;
using StockManager.Infra.Multitenancy;
using System;
using System.Data.Entity;

namespace StockManager.AdministrationContext.Infra.Data
{
    public class AdministrationDbContext : DbContext
    {
        public DbSet<ProductTable> Products { get; set; }

        public AdministrationDbContext(Tenant tenant) : base(tenant.ConnStr)
        {
         
        }
    }
}
