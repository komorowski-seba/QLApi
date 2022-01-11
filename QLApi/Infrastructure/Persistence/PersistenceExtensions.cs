using Application.Interfaces;
using Domain.Common;
using Infrastructure.Persistence.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistenceServices (this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        services.AddScoped<IProvinceRepository, ProvinceRepository>();
        services.AddScoped<IAirTestHistoryRepository, AirTestHistoryRepository>();
        return services;
    }

    public static IApplicationBuilder UsePersistenceConfiguration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();
        var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
        if (!dbContext?.Database.GetPendingMigrations().Any() ?? true) 
            return app;

        dbContext.Database.SetCommandTimeout(TimeSpan.FromMinutes(2));
        dbContext.Database.Migrate();
        return app;
    }
}
