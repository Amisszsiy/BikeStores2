using Microsoft.Extensions.Options;

namespace BikeStores2.Infrastructure.ExternalServices
{
    public static class HttpClientExtensions
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient("product", client =>
            {
                client.DefaultRequestHeaders.Add("Authorization", "123");
                client.DefaultRequestHeaders.Add("User-Agent", "123");

                client.BaseAddress = new Uri("https://localhost:7217/");
            });

            return services;
        }
    }
}
