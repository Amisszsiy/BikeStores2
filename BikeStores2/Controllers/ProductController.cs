using BikeStores2.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStores2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBikeStoresDbContext _context;
        public ProductController(IBikeStoresDbContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("/getproducts")]
        public async Task<IActionResult> GetProductAsync()
        {
            var products = await _context.Products.ToListAsync();

            return Ok(products);
        }
    }
}
