using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
      [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
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
            var products= await _context.products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Getproduct(int id)
        {
            return await _context.products.FindAsync(id);
        }
        
    }
}