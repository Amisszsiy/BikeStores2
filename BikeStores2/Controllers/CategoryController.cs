using BikeStores2.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStores2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBikeStoresDbContext _dbContext;

        public CategoryController(IBikeStoresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("/getcategorylistasync")]
        public async Task<IActionResult> GetCategoryListAsync() {
            var categoryList = await _dbContext.Categories.ToListAsync();
            return Ok(categoryList);
        }
    }
}
