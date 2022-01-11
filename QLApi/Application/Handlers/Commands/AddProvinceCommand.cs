using Application.Models.ProvinceDto;
using MediatR;
using Application.Interfaces;
using Domain.Common;
using Domain.Entities.ProvinceContext;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Handlers.Commands;

public class AddProvinceCommand : INotification
{
    public ProvinceDto Province { get; set; }
}

public class AddProvinceCommandHandler : INotificationHandler<AddProvinceCommand>
{
    private readonly IApplicationDbContext? _dbContext;
    private readonly IProvinceRepository? _provinceRepository;

    public AddProvinceCommandHandler(IServiceProvider serviceProvider)
    {
        var provider = serviceProvider.CreateScope().ServiceProvider; 
        _provinceRepository = provider.GetService<IProvinceRepository>();
        _dbContext = provider.GetService<IApplicationDbContext>();
    }

    public async Task Handle(AddProvinceCommand notification, CancellationToken cancellationToken)
    {
        if (_provinceRepository == null)
            throw new NullReferenceException(nameof(IProvinceRepository));
        if (_dbContext == null)
            throw new NullReferenceException(nameof(IApplicationDbContext));
        
        var find = await _provinceRepository.GetProvinceByNameAsync(notification.Province.Name);
        if (find != null)
            return;

        var province = MapProvince(notification.Province);
        await _provinceRepository.AddProvinceAsync(province);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private Province MapProvince(ProvinceDto provinceDto)
    {
        var result = new Province(provinceDto.Name);
        foreach (var communeDto in provinceDto.Communes)
        {
            var commune = result.AddCommune(provinceDto.Name, communeDto.DistrictName, communeDto.CommuneName);
            foreach (var cityDto in communeDto.Citys)
            {
                var city = commune.AddCity(cityDto.Id, cityDto.Name);
                foreach (var stationDto in cityDto.Stations)
                    city.AddStation(stationDto.Id, stationDto.StationName, stationDto.GegrLat, stationDto.GegrLon, stationDto.AddressStreet);
            }
        }
        return result;
    }
}