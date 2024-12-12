using System;
using MediatR;
using Reports.Application.Dtos;
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
        var pendingEntity = await _repository.GetValuesByDateAsync(request.Start, request.End);
        if (pendingEntity == null)
             throw new ArgumentNullException(nameof(request));
        return MapperLazyConf.Mapper.Map<IEnumerable<PendingValidation>, IEnumerable<PendingValidationDto>>(pendingEntity);
    }
}
