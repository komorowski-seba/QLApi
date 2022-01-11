using System.Text;
using Application.Interfaces;
using Application.Models.GiosStationModels;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Infrastructure.Redis;

public class RedisService : IRedisService
{
    private const string VariableKey = "stations";
    private readonly IDistributedCache _distributedCache;

    public RedisService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task SaveAllStations(IList<Station> stations)
    {
        var allStations = stations
            .Select(n => new Application.Models.Redis.Station
            {
                Id = n.Id,
                GegrLat = n.GegrLat,
                GegrLon = n.GegrLon,
                StationName = n.StationName,
                City = n.City.Name,
                Province = n.City.Commune.ProvinceName
            })
            .ToList();

        var stationSerialize = JsonConvert.SerializeObject(allStations);
        var stationToByte = Encoding.ASCII.GetBytes(stationSerialize);
        await _distributedCache.SetAsync(VariableKey, stationToByte);
    }

    public async Task<IList<Application.Models.Redis.Station>> GetAllStations()
    {
        var stationsToByte = await _distributedCache.GetAsync(VariableKey);
        if (stationsToByte == null)
            return new List<Application.Models.Redis.Station>();

        var result = JsonConvert
                         .DeserializeObject<List<Application.Models.Redis.Station>>(
                             Encoding.ASCII.GetString(stationsToByte));
        return result;
    }
}