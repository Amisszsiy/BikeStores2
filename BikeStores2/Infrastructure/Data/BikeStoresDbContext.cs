using BikeStores2.Domain.Interfaces;
using BikeStores2.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStores2.Infrastructure.Data
{
    public class BikeStoresDbContext : DbContext, IBikeStoresDbContext
    {
        public BikeStoresDbContext(DbContextOptions<BikeStoresDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
