using Application.Models.ProvinceDto;
using AutoMapper;
using Domain.Entities.AirAnalysisContext;
using Domain.Entities.ProvinceContext;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Station, StationDto>()
            .ForMember(d => d.Id, o => o.MapFrom(n => n.Id))
            .ForMember(d => d.AddressStreet, o => o.MapFrom(n => n.AddressStreet))
            .ForMember(d => d.GegrLat, o => o.MapFrom(n => n.GegrLat))
            .ForMember(d => d.GegrLon, o => o.MapFrom(n => n.GegrLon))
            .ForMember(d => d.StationName, o => o.MapFrom(n => n.StationName));
        
        CreateMap<City, CityDto>()
            .ForMember(d => d.Id, o => o.MapFrom(n => n.Id))
            .ForMember(d => d.Name, o => o.MapFrom(n => n.Name))
            .ForMember(d => d.Stations, o => o.MapFrom(n => n.Stations));
        
        CreateMap<Commune, CommuneDto>()
            .ForMember(d => d.Id, o => o.MapFrom(n => n.Id))
            .ForMember(d => d.CommuneName, o => o.MapFrom(n => n.CommuneName))
            .ForMember(d => d.DistrictName, o => o.MapFrom(n => n.DistrictName))
            .ForMember(d => d.Citys, o => o.MapFrom(n => n.Cities));

        CreateMap<Province, ProvinceDto>()
            .ForMember(d => d.Name, o => o.MapFrom(n => n.Name))
            .ForMember(d => d.Id, o => o.MapFrom(n => n.Id.ToString()))
            .ForMember(d => d.Communes, o => o.MapFrom(n => n.Communes));

        CreateMap<AirTest, AirTestDto>()
            .ForMember(d => d.StationId, o => o.MapFrom(n => n.StationId))
            .ForMember(d => d.CalcDate, o => o.MapFrom(n => n.CalcDate))
            .ForMember(d => d.DownloadDate, o => o.MapFrom(n => n.DownloadDate))
            .ForMember(d => d.No2IndexLevel, o => o.MapFrom(n => n.No2IndexLevel))
            .ForMember(d => d.No2IndexName, o => o.MapFrom(n => n.No2IndexName))
            .ForMember(d => d.O3IndexLevel, o => o.MapFrom(n => n.O3IndexLevel))
            .ForMember(d => d.O3IndexName, o => o.MapFrom(n => n.O3IndexName))
            .ForMember(d => d.Pm10IndexLevel, o => o.MapFrom(n => n.Pm10IndexLevel))
            .ForMember(d => d.Pm10IndexName, o => o.MapFrom(n => n.Pm10IndexName))
            .ForMember(d => d.Pm25IndexLevel, o => o.MapFrom(n => n.Pm25IndexLevel))
            .ForMember(d => d.Pm25IndexName, o => o.MapFrom(n => n.Pm25IndexName))
            .ForMember(d => d.So2IndexLevel, o => o.MapFrom(n => n.So2IndexLevel))
            .ForMember(d => d.So2IndexName, o => o.MapFrom(n => n.So2IndexName));

        CreateMap<AirTestHistory, AirTestHistoryDto>()
            .ForMember(d => d.StationId, o => o.MapFrom(n => n.StationId))
            .ForMember(d => d.UpdateDate, o => o.MapFrom(n => n.UpdateDate))
            .ForMember(d => d.AirTests, o => o.MapFrom(n => n.AirTests));
    }
}