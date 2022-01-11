using Application.Models.Settings;

namespace Application.Interfaces
{
    public interface IAppsettingsConfigServices
    {
        public GiosStationSettings GiosStation { get; init; }
    }
}