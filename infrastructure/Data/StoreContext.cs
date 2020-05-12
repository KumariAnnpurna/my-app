
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data
{
    public class StoreContext : DbContext

    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Product>products{get;set;}
        public DbSet<ProductBrand>productBrands{get;set;}
        public DbSet<ProductType>productTypes{get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}