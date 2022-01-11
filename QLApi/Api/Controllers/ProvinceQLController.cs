using Application.Handlers.Query;
using Application.Models.ProvinceDto;
using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using MediatR;

namespace Api.Controllers;

[GraphRoute("provinces")]
public class ProvinceQLController : GraphController
{
    private readonly IMediator _mediator;

    public ProvinceQLController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Query("province")]
    public async Task<ProvinceDto> GetProvince(Guid id)
    {
        var result = await _mediator.Send(new GetProvinceQuery {Id = id});
        return result;
    }
    
    [Query("list")]
    public async Task<IEnumerable<ProvinceDto>> GetAllProvinces()
    {
        var result = await _mediator.Send(new GetAllProvincesQuery());
        return result;
    }
}