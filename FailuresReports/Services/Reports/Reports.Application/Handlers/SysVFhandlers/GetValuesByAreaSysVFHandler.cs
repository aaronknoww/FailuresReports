using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;
using MediatR;
using Reports.Application.Exceptions;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetValuesByAreaSysVFHandler : IRequestHandler<GetAllFailureByAreaSysQuery<FailureRegistrationSYSVFDto>, IEnumerable<FailureRegistrationSYSVFDto>>
{
    private readonly ISYSVFFailureRepository _repository;

    public GetValuesByAreaSysVFHandler(ISYSVFFailureRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<FailureRegistrationSYSVFDto>> Handle(GetAllFailureByAreaSysQuery<FailureRegistrationSYSVFDto> request, CancellationToken cancellationToken)
    {
        var sysvfEntity = await _repository.GetAllFailuresByAreaAsync(request.testArea);
        if (sysvfEntity == null || sysvfEntity.Count() == 0)
             throw new EntityNotFoundException($"There are no failures registered by this test area {request.testArea}.");
        //TODO: generate logs if the operation fail or if is succesfull.
        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSVF>, IEnumerable<FailureRegistrationSYSVFDto>>(sysvfEntity);
    }
}
