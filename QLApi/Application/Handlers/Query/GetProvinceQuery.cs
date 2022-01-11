using Application.Models.ProvinceDto;
using AutoMapper;
using Domain.Common;
using MediatR;

namespace Application.Handlers.Query;

public class GetProvinceQuery : IRequest<ProvinceDto>
{
    public Guid Id { get; set; }
}

public class GetProvinceHandler : IRequestHandler<GetProvinceQuery, ProvinceDto>
{
    private IProvinceRepository _provinceRepository;
    private IMapper _mapper;

    public GetProvinceHandler(IProvinceRepository provinceRepository, IMapper mapper)
    {
        _provinceRepository = provinceRepository;
        _mapper = mapper;
    }

    public async Task<ProvinceDto> Handle(GetProvinceQuery request, CancellationToken cancellationToken)
    {
        var find = await _provinceRepository.GetProvinceByIdAsync(request.Id);
        if (find == null)
            throw new Exception(" nie zlaleziono");
        var result = _mapper.Map<ProvinceDto>(find);
        return result;
    }
}