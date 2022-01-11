using Application.Interfaces;
using Hangfire;

namespace Infrastructure.Hangfire;

public class HangfireJobsService : IHangfireJobsService
{
    private readonly IStationsService _stationsService;

    public HangfireJobsService(IStationsService stationsService)
    {
        _stationsService = stationsService;
    }

    [JobDisplayName("AllProvincesJob_{0}"), AutomaticRetry(Attempts = 0)]
    public void AllProvincesJob()
    {
        _stationsService.AllProvinces().Wait();
    }

    [JobDisplayName("CheckAllStations_{0}"), AutomaticRetry(Attempts = 0)]
    public void CheckAllStations()
    {
        _stationsService.CheckAllStations().Wait();
    }
}