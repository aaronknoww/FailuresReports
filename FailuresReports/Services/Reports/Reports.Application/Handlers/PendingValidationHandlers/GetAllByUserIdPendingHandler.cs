using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.PendingValidationHandlers;

public class GetAllByUserIdPendingHandler : IRequestHandler<GetAllByUserIdQuery<PendingValidationDto>, IEnumerable<PendingValidationDto>>
{
    //TODO: is necessary implement a date range
    private readonly IPendingValidationRepository _repository;

    public GetAllByUserIdPendingHandler(IPendingValidationRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<PendingValidationDto>> Handle(GetAllByUserIdQuery<PendingValidationDto> request, CancellationToken cancellationToken)
    {
        //TODO: VALIDATOR to check request values
        
        IEnumerable<PendingValidation> pendingEntity = await _repository.GetAllByUserIdAsync(request.userId, request.start, request.end, request.maxRows);
        if (pendingEntity == null || pendingEntity.Count() == 0)
             throw new EntityNotFoundException(nameof(PendingValidation), request.userId);
        
        //TODO: explain in the logs what happend with the operation.
        return MapperLazyConf.Mapper.Map<IEnumerable<PendingValidation>, IEnumerable<PendingValidationDto>>(pendingEntity);
    }
}
