using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Common.Behaviors;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Services;
//for add Application services to the DI container
namespace TaskManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
//لسه شغاله ب سيرفزلير خلي بالك
        services.AddScoped<IUserService, UserService>();

 
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        // Pipeline Behavior  يشتغل تلقائي قبل أي Handler
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));

        return services;
    }
}