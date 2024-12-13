using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetFailureByTypeSysVFHandler : IRequestHandler<GetFailureByTypeSysQuery<FailureRegistrationSYSVFDto>, IEnumerable<FailureRegistrationSYSVFDto>>
{
    private readonly ISYSVFFailureRepository _repository;

    public GetFailureByTypeSysVFHandler(ISYSVFFailureRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<FailureRegistrationSYSVFDto>> Handle(GetFailureByTypeSysQuery<FailureRegistrationSYSVFDto> request, CancellationToken cancellationToken)
    {
        var sysvfEntity = await _repository.GetFailureByType(request.type);
        if (sysvfEntity == null)
             throw new ArgumentNullException(nameof(request));
        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSVF>, IEnumerable<FailureRegistrationSYSVFDto>>(sysvfEntity);
    }
}

