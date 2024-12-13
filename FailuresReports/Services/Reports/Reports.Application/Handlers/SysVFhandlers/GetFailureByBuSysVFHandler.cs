using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetFailureByBuSysVFHandler : IRequestHandler<GetFailureByAreaSysQuery<FailureRegistrationSYSVFDto>, IEnumerable<FailureRegistrationSYSVFDto>>
{
    private readonly ISYSVFFailureRepository _repository;

    public GetFailureByBuSysVFHandler(ISYSVFFailureRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<FailureRegistrationSYSVFDto>> Handle(GetFailureByBuSysQuery<FailureRegistrationSYSVFDto> request, CancellationToken cancellationToken)
    {
        var sysvfEntity = await _repository.GetFailureByBu(request.bu);
        if (sysvfEntity == null)
             throw new ArgumentNullException(nameof(request));
        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSVF>, IEnumerable<FailureRegistrationSYSVFDto>>(sysvfEntity);
    }
}
