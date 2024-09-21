using BikeStores2.Domain.Interfaces;
using BikeStores2.Domain.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.IO;

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

        [HttpGet]
        [Route("/getproductasync/{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var product = await _context.Products.Include(u => u.brand).ToListAsync();
            var p = product.Find(u => u.product_id == id);
            return Ok(p);
        }

        [HttpPost]
        [Route("/import")]
        public async Task<IActionResult> Import([FromBody]IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please upload a valid XLSX file.");
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                using (var workbook = new XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheet(1); // Assuming you want to read the first worksheet
                    var rows = worksheet.RowsUsed();

                    foreach (var row in rows.Skip(1)) // Assuming first row is header
                    {
                        var product = new Product
                        {
                            product_name = row.Cell(1).GetString(),
                            brand_id = row.Cell(2).GetValue<int>(),
                            category_id = row.Cell(3).GetValue<int>(),
                            model_year = row.Cell(4).GetValue<Int16>(),
                            list_price = row.Cell(5).GetValue<decimal>(),
                        };
                        _context.Products.Add(product);
                    }

                    _context.Save();
                }


            }

            return Ok("File imported successfully.");
        }
    }
}
