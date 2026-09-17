namespace OrderManagement.Application.Interfaces;

public interface IOrderService
{
    Task<List<OrderDto>> GetAllOrdersAsync();
    Task<OrderDto> GetOrderByIdAsync(int id);
    Task<OrderDto> CreateOrderAsync(CreateOrderDto dto);
    Task<OrderDto> UpdateOrderStatusAsync(int id, UpdateOrderStatusDto dto);
    Task DeleteOrderAsync(int id);
}
