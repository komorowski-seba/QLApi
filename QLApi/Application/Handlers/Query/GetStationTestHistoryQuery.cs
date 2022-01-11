using Application.Models.ProvinceDto;
using AutoMapper;
using Domain.Common;
using Domain.Entities.AirAnalysisContext;
using MediatR;

namespace Application.Handlers.Query;

public class GetStationTestHistoryQuery : IRequest<AirTestHistoryDto>
{
    public long Id { get; set; }
}

public class GetStationTestHistoryQueryHandler : IRequestHandler<GetStationTestHistoryQuery, AirTestHistoryDto>
{
    private readonly IMapper _mapper;
    private readonly IAirTestHistoryRepository _historyRepository;

    public GetStationTestHistoryQueryHandler(IMapper mapper, IAirTestHistoryRepository historyRepository)
    {
        _mapper = mapper;
        _historyRepository = historyRepository;
    }

    public async Task<AirTestHistoryDto> Handle(GetStationTestHistoryQuery request, CancellationToken cancellationToken)
    {
        var find = await _historyRepository.GetAirTestHistoryNoTrack(request.Id);
        if (find == null)
            throw new NullReferenceException(nameof(AirTestHistory));
        
        var result = _mapper.Map<AirTestHistoryDto>(find);
        return result;
    }
}