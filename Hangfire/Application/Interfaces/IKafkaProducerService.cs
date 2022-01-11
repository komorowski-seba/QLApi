using Application.Models.Commands;
using Application.Models.Dto;

namespace Application.Interfaces;

public interface IKafkaProducerService
{
    Task ProvinceMessageAsync(IList<ProvinceDto> provinces);
    Task AirTestMessageAsync(AddStationStateCommand stationStateCommand);
}