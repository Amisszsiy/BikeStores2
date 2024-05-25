using BikeStores2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BikeStores2.Infrastructure.Data
{
    public static class DatabaseServices
    {
        public static IServiceCollection AddDatabaseService(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<IBikeStoresDbContext,BikeStoresDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BikeStores"));
            });
            return services;
        }
    }
}
