using Application.Interfaces;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Hangfire;

public static class HangfireExtension
{
    public static IServiceCollection AddHangfireServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHangfire(globalConfiguration => globalConfiguration
            .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection")));
        services.AddHangfireServer();
        services.AddScoped<IHangfireJobsService, HangfireJobsService>();
        return services;
    }
    
    public static IApplicationBuilder UseHangfireConfiguration(this IApplicationBuilder app)
    {
        app.UseHangfireDashboard("/hangfire", new DashboardOptions {Authorization = new [] { new AuthorizationFilter() }});
        CleanJobs();

        // BackgroundJob.Enqueue<IHangfireJobsService>( n => n.AllProvincesJob() );
        BackgroundJob.Schedule<IHangfireJobsService>(n => n.CheckAllStations(), TimeSpan.FromMinutes(2));

        return app;
    }
        
    private static void CleanJobs()
    {
        using var connection = JobStorage.Current.GetConnection();
        foreach (var recurringJob in connection.GetRecurringJobs())
        {
            RecurringJob.RemoveIfExists(recurringJob.Id);
        }
    }
}
    
internal class AuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context) => true;
}