using Application.Models.Settings;

namespace Application.Interfaces
{
    public interface IAppsettingsConfigServices
    {
        // public ElasticSettings Elastic { get; init; }
        public DbConnectionStrings DbConnection { get; init; }
    }
}