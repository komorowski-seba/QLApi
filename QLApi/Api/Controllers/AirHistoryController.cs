using Application.Handlers.Query;
using Application.Models.ProvinceDto;
using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using MediatR;

namespace Api.Controllers;

[GraphRoute("airHistory")]
public class AirHistoryController : GraphController
{
    private readonly IMediator _mediator;

    public AirHistoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Query("list")]
    public async Task<IEnumerable<AirTestHistoryDto>> GetAllAirHistory()
    {
        var result = await _mediator.Send(new GetAllAirHistoryQuery());
        return result;
    }
    
    [Query("station")]
    public async Task<AirTestHistoryDto> GetStationTestHistory(long id)
    {
        var result = await _mediator.Send(new GetStationTestHistoryQuery {Id = id});
        return result;
    }
}