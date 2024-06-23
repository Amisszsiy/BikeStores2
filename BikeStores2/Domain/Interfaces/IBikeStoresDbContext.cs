using BikeStores2.Domain.Models;
using Microsoft.EntityFrameworkCore;

//Define what tables should this DbContext implement

namespace BikeStores2.Domain.Interfaces
{
    public interface IBikeStoresDbContext
    {
        public DbSet<Product> Products { get; }
        public DbSet<Category> Categories { get;}
        public DbSet<Brand> Brands { get; }

        public void Save();
    }
}
