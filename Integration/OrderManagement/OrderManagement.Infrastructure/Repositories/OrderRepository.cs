namespace OrderManagement.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _context;

    public OrderRepository(OrderDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetAllAsync() => await _context.Orders.Include(o => o.Items).AsNoTracking().ToListAsync();

    public async Task<Order?> GetByIdAsync(int id)=> await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);

    public async Task AddAsync(Order order)=> await _context.Orders.AddAsync(order);

    public void Update(Order order)=> _context.Orders.Update(order);

    public void Delete(Order order)=> _context.Orders.Remove(order);

    public async Task<bool> SaveChangesAsync()=> await _context.SaveChangesAsync() > 0;
}
