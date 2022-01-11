using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Redis;

public static class RedisExtension
{
    public static IServiceCollection AddRedisServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDistributedRedisCache(option =>
        {
            option.Configuration = configuration.GetValue<string>("Redis:Configuration");
            option.InstanceName = configuration.GetValue<string>("Redis:InstanceName");
        });
        services.AddScoped<IRedisService, RedisService>();
        return services;
    }
}