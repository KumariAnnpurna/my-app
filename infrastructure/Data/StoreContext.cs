
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
    }
}