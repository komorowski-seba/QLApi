using Application.Models.ProvinceDto;
using AutoMapper;
using Domain.Common;
using MediatR;

namespace Application.Handlers.Query;

public class GetAllProvincesQuery : IRequest<IEnumerable<ProvinceDto>>
{
}

public class GetAllProvincesHandler : IRequestHandler<GetAllProvincesQuery, IEnumerable<ProvinceDto>>
{
    private readonly IProvinceRepository _provinceRepository;
    private readonly IMapper _mapper;

    public GetAllProvincesHandler(IProvinceRepository provinceRepository, IMapper mapper)
    {
        _provinceRepository = provinceRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProvinceDto>> Handle(GetAllProvincesQuery request, CancellationToken cancellationToken)
    {
        var list = await _provinceRepository.GetAllAsync();
        var result = _mapper.Map<IEnumerable<ProvinceDto>>(list);
        return result;
    }
}