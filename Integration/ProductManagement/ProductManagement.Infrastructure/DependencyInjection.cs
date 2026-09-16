

namespace ProductManagement.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(connectionString));
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
