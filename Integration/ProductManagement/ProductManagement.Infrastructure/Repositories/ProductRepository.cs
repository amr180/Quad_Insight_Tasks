namespace ProductManagement.Infrastructure.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()=> await _context.Products.AsNoTracking().ToListAsync();
    public async Task<Product?> GetByIdAsync(int id)=> await _context.Products.FindAsync(id);

    public async Task AddAsync(Product product)=> await _context.Products.AddAsync(product);
    public void Update(Product product) => _context.Products.Update(product);

    public void Delete(Product product) => _context.Products.Remove(product);

    public async Task<bool> SaveChangesAsync()=> await _context.SaveChangesAsync() > 0;
}
