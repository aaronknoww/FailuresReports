using System;
using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.PendingValidationHandlers;

public class GetValuesByDatePendingHandler : IRequestHandler<GetValuesByDateQuery<PendingValidationDto>, IEnumerable<PendingValidationDto>>
{
    private readonly IPendingValidationRepository _repository;

    public GetValuesByDatePendingHandler(IPendingValidationRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<PendingValidationDto>> Handle(GetValuesByDateQuery<PendingValidationDto> request, CancellationToken cancellationToken)
    {
        //TODO: VALIDATORS FOR REQUEST VALUES
        IEnumerable<PendingValidation> pendingEntity = await _repository.GetValuesByDateAsync(request.Start, request.End, request.maxRows);
        if (pendingEntity == null || pendingEntity.Count() == 0)
             throw new EntityNotFoundException($"There is no pending validation {nameof(PendingValidation)}", request);
        //TODO: generate logs if the operation fail or if is succesfull.
        return MapperLazyConf.Mapper.Map<IEnumerable<PendingValidation>, IEnumerable<PendingValidationDto>>(pendingEntity);
    }
}
