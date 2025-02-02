using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
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
        //TODO: VALIDATOR FOR ALL REQUEST VALUES
        IEnumerable<PendingValidation> pendingEntity = await _repository.GetAllPendingValidationAsync(request.start, request.end, request.maxRows);

        if (pendingEntity == null || pendingEntity.Count() == 0)
             throw new EntityNotFoundException($"There are no pendig validations {nameof(request)}.");
        //TODO: generate logs if the operation fail or if is succesfull.
       
        return MapperLazyConf.Mapper.Map<IEnumerable<PendingValidation>, IEnumerable<PendingValidationDto>>(pendingEntity);
    }
}
