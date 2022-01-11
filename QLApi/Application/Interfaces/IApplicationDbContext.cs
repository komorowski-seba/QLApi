using Domain.Entities.AirAnalysisContext;
using Domain.Entities.ProvinceContext;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Province> Provinces { get; init; }
        DbSet<Commune> Communes { get; init; }
        DbSet<City> Cities { get; init; }
        DbSet<Station> Stations { get; init; }
        DbSet<AirTest> AirTests { get; init; }
        DbSet<AirTestHistory> AirTestHistories { get; init; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}