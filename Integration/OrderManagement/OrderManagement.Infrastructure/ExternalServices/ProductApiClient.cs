using OrderManagement.Application.DTOs;
using System.Net.Http.Json;
namespace OrderManagement.Infrastructure.ExternalServices
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly HttpClient _httpClient;

        public ProductApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExternalProductDto?> GetProductByIdAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"api/products/{productId}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<ExternalProductDto>();
        }
    }
}
