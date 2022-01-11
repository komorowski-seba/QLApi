using Application.Interfaces;
using Domain.Common;
using Domain.Entities.ProvinceContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Services;

public class ProvinceRepository : IProvinceRepository
{
    private readonly IApplicationDbContext _applicationDb;

    public ProvinceRepository(IApplicationDbContext applicationDb)
    {
        _applicationDb = applicationDb;
    }

    public async Task AddProvinceAsync(Province province)
    {
        await _applicationDb.Provinces.AddAsync(province);
    }

    public async Task<Province?> GetProvinceByIdAsync(Guid id)
    {
        var result = await _applicationDb
            .Provinces
            .Include(n => n.Communes).ThenInclude(n => n.Cities)
            .FirstOrDefaultAsync(n => n.Id.Equals(id));
        return result;
    }

    public async Task<Province?> GetProvinceByNameAsync(string name)
    {
        var result = await _applicationDb
            .Provinces
            .Include(n => n.Communes)
            .FirstOrDefaultAsync(n => n.Name.Equals(name));
        return result;
    }

    public Task<List<Province>> GetAllAsync()
    {
        var result = _applicationDb
            .Provinces
            .Include(n => n.Communes).ThenInclude(n => n.Cities)
            .ToListAsync();
        return result;
    }
}