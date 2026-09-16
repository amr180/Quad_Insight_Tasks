namespace OrderManagement.Application.Interfaces
{
    public interface IProductApiClient
    {
        Task<ExternalProductDto?> GetProductByIdAsync(int productId);
    }
}
