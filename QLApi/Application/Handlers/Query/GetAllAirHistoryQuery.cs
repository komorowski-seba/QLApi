using System.Runtime.InteropServices;
using Application.Models.ProvinceDto;
using AutoMapper;
using Domain.Common;
using MediatR;

namespace Application.Handlers.Query;

public class GetAllAirHistoryQuery : IRequest<IEnumerable<AirTestHistoryDto>>
{
}

public class GetAllAirHistoryQueryHandler : IRequestHandler<GetAllAirHistoryQuery, IEnumerable<AirTestHistoryDto>>
{
    private readonly IAirTestHistoryRepository _historyRepository;
    private readonly IMapper _mapper;

    public GetAllAirHistoryQueryHandler(IAirTestHistoryRepository historyRepository, IMapper mapper)
    {
        _historyRepository = historyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AirTestHistoryDto>> Handle(GetAllAirHistoryQuery request, CancellationToken cancellationToken)
    {
        var allAir = await _historyRepository.GetAllAirTestHistory();
        var result = _mapper.Map<IEnumerable<AirTestHistoryDto>>(allAir);
        return result;
    }
}