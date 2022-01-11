using Application.Interfaces;
using Application.Models.Commands;
using Application.Models.Dto;

namespace Application.Services;

public class StationsService : IStationsService
{
    private readonly IGiosService _giosService;
    private readonly IKafkaProducerService _kafkaProducerService;
    private readonly IRedisService _redisService;

    public StationsService(IGiosService giosService, 
        IKafkaProducerService kafkaProducerService, 
        IRedisService redisService)
    {
        _giosService = giosService;
        _kafkaProducerService = kafkaProducerService;
        _redisService = redisService;
    }

    public async Task AllProvinces()
    {
        var stations = await _giosService.GetAllProvinces();
        var provinces = _giosService.MapToProvinces(stations);
        
        await _redisService.SaveAllStations(stations);
        await _kafkaProducerService.ProvinceMessageAsync(provinces);
    }

    public async Task CheckAllStations()
    {
        var result = await _redisService.GetAllStations();
        var airTestTasks = result
            .Where(n => n.Id > 0)
            .Select(n => Task.Run(async () =>
            {
                var airTest = await _giosService.GetStationAirQuality(n.Id, n.Province, n.City);
                await _kafkaProducerService.AirTestMessageAsync(new AddStationStateCommand
                {
                    AirTest = new AirTestDto()
                    {
                        StationId = airTest.Id,
                        ProvinceName = airTest.ProvinceName,
                        CityName = airTest.CityName,
                        CalcDate = airTest.CalculateDate.DateTime,
                        DownloadDate = DateTime.UtcNow,
                        
                        No2IndexLevel = airTest.No2IndexLevel?.Value ?? int.MaxValue,
                        No2IndexName = airTest.No2IndexLevel?.IndexLevelName ?? "null",
                        O3IndexLevel = airTest.O3IndexLevel?.Value ?? int.MaxValue,
                        O3IndexName = airTest.O3IndexLevel?.IndexLevelName ?? "null",
                        Pm25IndexLevel = airTest.Pm25IndexLevel?.Value ?? int.MaxValue,
                        Pm25IndexName = airTest.Pm25IndexLevel?.IndexLevelName ?? "null",
                        Pm10IndexLevel = airTest.Pm10IndexLevel?.Value ?? int.MaxValue,
                        Pm10IndexName = airTest.Pm10IndexLevel?.IndexLevelName ?? "null",
                        So2IndexName = airTest.So2IndexLevel?.IndexLevelName ?? "null",
                        So2IndexLevel = airTest.So2IndexLevel?.Value ?? int.MaxValue,
                    }
                });
            }))
            .ToList();
        await Task.WhenAll(airTestTasks);
    }
}