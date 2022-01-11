using Application.Models.Dto;
using Application.Models.GiosStationModels;

namespace Application.Interfaces
{
    public interface IGiosService
    {
        Task<IList<Station>> GetAllProvinces();
        IList<ProvinceDto> MapToProvinces(IList<Station> stations);
        Task<IndexAirQuality> GetStationAirQuality(long stationId, string provinceName, string cityName);
    }
}