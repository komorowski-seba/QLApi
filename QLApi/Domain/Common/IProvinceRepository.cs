using Domain.Entities.ProvinceContext;

namespace Domain.Common;

public interface IProvinceRepository : IRepository<Province>
{
    Task AddProvinceAsync(Province province);
    Task<Province?> GetProvinceByIdAsync(Guid id);
    Task<Province?> GetProvinceByNameAsync(string name);
    Task<List<Province>> GetAllAsync();
}