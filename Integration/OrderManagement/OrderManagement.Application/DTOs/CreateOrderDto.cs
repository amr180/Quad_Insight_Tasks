namespace OrderManagement.Application.DTOs;
public class CreateOrderDto
{
    public string CustomerName { get; set; } = string.Empty;
    public List<CreateOrderItemDto> Items { get; set; } = new();
}
