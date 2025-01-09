using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetFailureByTypeSysVFHandler : IRequestHandler<GetAllFailureByTypeSysQuery<FailureRegistrationSYSVFDto>, IEnumerable<FailureRegistrationSYSVFDto>>
{
    private readonly ISYSVFFailureRepository _repository;

    public GetFailureByTypeSysVFHandler(ISYSVFFailureRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<FailureRegistrationSYSVFDto>> Handle(GetAllFailureByTypeSysQuery<FailureRegistrationSYSVFDto> request, CancellationToken cancellationToken)
    {
        var sysvfEntity = await _repository.GetAllFailureByTypeAsync(request.type);
        
        if (sysvfEntity == null || sysvfEntity.Count() == 0)
             throw new EntityNotFoundException($"There are no failures registered by this {request.type}.");
        //TODO: generate logs if the operation fail or if is succesfull.
        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSVF>, IEnumerable<FailureRegistrationSYSVFDto>>(sysvfEntity);
    }
}

