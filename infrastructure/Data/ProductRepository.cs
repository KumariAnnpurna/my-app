using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.interfaces;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.productBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.products
             .Include(p => p.ProductBrand)
             .Include(p => p.ProductType)
            .FirstOrDefaultAsync(p => p.Id==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.products
             .Include(p => p.ProductBrand)
             .Include(p => p.ProductType)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.productTypes.ToListAsync();
        }
    }
}