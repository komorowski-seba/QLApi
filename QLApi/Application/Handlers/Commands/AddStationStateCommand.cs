using Application.Interfaces;
using Application.Models.ProvinceDto;
using Domain.Common;
using Domain.Entities.AirAnalysisContext;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Handlers.Commands;

public class AddStationStateCommand : INotification
{
    public AirTestDto AirTest { get; set; }
}

public class AddStationStateCommandHandler : INotificationHandler<AddStationStateCommand>
{
    private readonly IAirTestHistoryRepository _historyRepository;
    private readonly IApplicationDbContext _dbContext;

    public AddStationStateCommandHandler(IServiceProvider serviceProvider)
    {
        var provider = serviceProvider.CreateScope().ServiceProvider; 
        _historyRepository = provider.GetService<IAirTestHistoryRepository>();
        _dbContext = provider.GetService<IApplicationDbContext>();
    }

    public async Task Handle(AddStationStateCommand notification, CancellationToken cancellationToken)
    {
        var airTest = notification.AirTest;
        var airHistory = await _historyRepository.GetAirTestHistory(notification.AirTest.StationId);
        if (airHistory == null)
        {
            airHistory = new AirTestHistory(airTest.StationId, airTest.CalcDate, airTest.DownloadDate,
                airTest.So2IndexLevel, airTest.So2IndexName, airTest.No2IndexLevel, airTest.No2IndexName,
                airTest.Pm10IndexLevel, airTest.Pm10IndexName, airTest.Pm25IndexLevel, airTest.Pm25IndexName,
                airTest.O3IndexLevel, airTest.O3IndexName);
            await _historyRepository.AddAirTestHistory(airHistory);
        }
        else
        {
            airHistory.AddAirTest(airTest.StationId, airTest.CalcDate, airTest.DownloadDate,
                airTest.So2IndexLevel, airTest.So2IndexName, airTest.No2IndexLevel, airTest.No2IndexName,
                airTest.Pm10IndexLevel, airTest.Pm10IndexName, airTest.Pm25IndexLevel, airTest.Pm25IndexName,
                airTest.O3IndexLevel, airTest.O3IndexName);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}