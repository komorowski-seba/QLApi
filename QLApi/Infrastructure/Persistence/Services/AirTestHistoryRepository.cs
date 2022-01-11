using Application.Interfaces;
using Domain.Common;
using Domain.Entities.AirAnalysisContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Services;

public class AirTestHistoryRepository : IAirTestHistoryRepository
{
    private readonly IApplicationDbContext _applicationDb;

    public AirTestHistoryRepository(IApplicationDbContext applicationDb)
    {
        _applicationDb = applicationDb;
    }

    public async Task<AirTestHistory?> GetAirTestHistory(long stationId)
    {
        var result = await _applicationDb
            .AirTestHistories
            // .Include(n => n.AirTests)
            .FirstOrDefaultAsync(n => n.StationId == stationId);
        return result;
    }

    public async Task AddAirTestHistory(AirTestHistory airTestHistory)
    {
        await _applicationDb.AirTestHistories.AddAsync(airTestHistory);
    }

    public async Task<IEnumerable<AirTestHistory>> GetAllAirTestHistory()
    {
        var result = await _applicationDb.AirTestHistories
            .Include(n => n.AirTests)
            .AsNoTracking()
            .ToListAsync();
        return result;
    }

    public async Task<AirTestHistory?> GetAirTestHistoryNoTrack(long stationId)
    {
        var result = await _applicationDb
            .AirTestHistories
            .AsNoTracking()
            .Include(n => n.AirTests)
            .FirstOrDefaultAsync(n => n.StationId == stationId);
        return result;
    }
}