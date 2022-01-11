using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Gios;

public static class GiosExtension
{
    public static IServiceCollection AddGiosServices(this IServiceCollection services)
    {
        services.AddScoped<IGiosService, GiosService>();
        return services;
    }
}