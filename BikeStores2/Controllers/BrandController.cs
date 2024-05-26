using BikeStores2.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStores2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBikeStoresDbContext _dbContext;

        public BrandController(IBikeStoresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/getbrandlistasync")]
        public async Task<IActionResult> GetBrandList() {
            var brandList = await _dbContext.Brands.ToListAsync();
            return Ok(brandList);
        }
    }
}
