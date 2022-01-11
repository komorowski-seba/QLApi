using Application.Interfaces;
using Application.Models.Settings;

namespace StationsJob.Services;

public class AppsettingsConfigServices : IAppsettingsConfigServices
{
    public GiosStationSettings GiosStation { get; init; }
    
    public AppsettingsConfigServices(IConfiguration configuration)
    {
        GiosStation = Bind<GiosStationSettings>(configuration, "GiosStation");
    }

    private static T Bind<T>(IConfiguration configuration, string key) where T : new()
    {
        var result = new T();
        configuration.Bind(key, result);
        return result;
    }
}