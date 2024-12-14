using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.PendingValidationQueries;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.PendingValidationHandlers;

public class GetAllPendingValidationHandler : IRequestHandler<GetAllPendingValidationQuery, IEnumerable<PendingValidationDto>>
{
    private readonly IPendingValidationRepository _repository;

    public GetAllPendingValidationHandler(IPendingValidationRepository repository)
    {
        this._repository = repository;
    }

    public async Task<IEnumerable<PendingValidationDto>> Handle(GetAllPendingValidationQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<PendingValidation> pendingEntity = await _repository.GetAllPendingValidationAsync();
        if(pendingEntity == null)
            throw new NullReferenceException(nameof(pendingEntity));
        
        return MapperLazyConf.Mapper.Map<IEnumerable<PendingValidation>, IEnumerable<PendingValidationDto>>(pendingEntity);
    }
}
