using Domain.Entities.AirAnalysisContext;

namespace Domain.Common
{
    public interface IAirTestHistoryRepository : IRepository<AirTestHistory>
    {
        Task<AirTestHistory?> GetAirTestHistory(long stationId);
        Task AddAirTestHistory(AirTestHistory airTestHistory);
        Task<IEnumerable<AirTestHistory>> GetAllAirTestHistory();
        Task<AirTestHistory?> GetAirTestHistoryNoTrack(long stationId);
    }
}