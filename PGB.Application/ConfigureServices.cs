using Microsoft.Extensions.DependencyInjection;
using PGB.Application.Interfaces;
using PGB.Application.Mapping;
using PGB.Application.Services;
using System.Reflection;

namespace PGB.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //Auto mapper
        services.AddAutoMapper(typeof(AutoMapperProfile));

        //Mediator
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        //Services
        services.AddScoped<IRegisterBookOrderService, RegisterBookOrderService>();


        return services;
    }
}
