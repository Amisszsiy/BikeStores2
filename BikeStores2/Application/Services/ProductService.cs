using BikeStores2.Domain.Models;

namespace BikeStores2.Application.Services
{
    public class ProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Product>?> GetProductsAsync()
        {
            var client = _httpClientFactory.CreateClient("product");

            List<Product>? products = await client.GetFromJsonAsync<List<Product>>("getproducts");

            return products;
        }
    }
}
