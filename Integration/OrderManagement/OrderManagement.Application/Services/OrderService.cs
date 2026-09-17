using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Exceptions;


namespace OrderManagement.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductApiClient _productApiClient;

    public OrderService(IOrderRepository orderRepository, IProductApiClient productApiClient)
    {
        _orderRepository = orderRepository;
        _productApiClient = productApiClient;
    }

    public async Task<List<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return orders.Select(MapToDto).ToList();
    }
    public async Task<OrderDto> GetOrderByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id)
            ?? throw new NotFoundException($"الطلب رقم {id} مش موجود");

        return MapToDto(order);
    }
    public async Task<OrderDto> CreateOrderAsync(CreateOrderDto dto)
    {
        var items = new List<OrderItem>();

        foreach (var itemDto in dto.Items)
        {
            var product = await _productApiClient.GetProductByIdAsync(itemDto.ProductId)
                ?? throw new NotFoundException($"المنتج رقم {itemDto.ProductId} مش موجود في ProductManagement");

            items.Add(new OrderItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                UnitPrice = product.Price,
                Quantity = itemDto.Quantity
            });
        }
        var order = new Order
        {
            CustomerName = dto.CustomerName,
            Status = OrderStatus.Pending,
            Items = items
        };

        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();

        return MapToDto(order);
    }

    public async Task<OrderDto> UpdateOrderStatusAsync(int id, UpdateOrderStatusDto dto)
    {
        var order = await _orderRepository.GetByIdAsync(id)?? throw new NotFoundException($"الطلب رقم {id} مش موجود");

        if (!Enum.TryParse<OrderStatus>(dto.Status, true, out var status)) throw new ArgumentException("حالة الطلب غير صالحة");
        order.Status = status;

        _orderRepository.Update(order);
        await _orderRepository.SaveChangesAsync();

        return MapToDto(order);
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id) ?? throw new NotFoundException($"الطلب رقم {id} مش موجود");

        _orderRepository.Delete(order);
        await _orderRepository.SaveChangesAsync();
    }

    private static OrderDto MapToDto(Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            CustomerName = order.CustomerName,
            OrderDate = order.OrderDate,
            Status = order.Status.ToString(),
            TotalAmount = order.TotalAmount,
            Items = order.Items.Select(i => new OrderItemDto
            {
                Id = i.Id,
                ProductId = i.ProductId,
                ProductName = i.ProductName,
                UnitPrice = i.UnitPrice,
                Quantity = i.Quantity
            }).ToList()
        };
    }
}
