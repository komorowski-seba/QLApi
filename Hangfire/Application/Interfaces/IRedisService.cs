using Application.Models.GiosStationModels;

namespace Application.Interfaces;

public interface IRedisService
{
    Task SaveAllStations(IList<Station> stations);
    Task<IList<Models.Redis.Station>> GetAllStations();
}