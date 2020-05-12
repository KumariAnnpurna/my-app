using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.interfaces;
using infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //   [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }
//  [HttpGet]
//         public ActionResult<List<Product>>Getproducts()
//         {
//             var products= _context.products.ToList();
//             return Ok(products);synchronus method : it is complex method
//         }
        [HttpGet]
        public async Task<ActionResult<List<Product>>>Getproducts()
        {
            var products= await _repo.GetProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Getproduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }  
         [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>>GetProductBrands()
        {
            var productbrands= await _repo.GetProductBrandsAsync();
            return Ok(productbrands);
        }
         [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>>GetProductTypes()
        {
            var producttypes= await _repo.GetProductTypesAsync();
            return Ok(producttypes);
        } 
        
    }
}