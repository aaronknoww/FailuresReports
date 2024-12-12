using System;
using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.PendingValidationHandlers;

public class GetAllByUserIdPendingHandler : IRequestHandler<GetAllByUserIdQuery<PendingValidationDto>, IEnumerable<PendingValidationDto>>
{
    private readonly IPendingValidationRepository _repository;

    public GetAllByUserIdPendingHandler(IPendingValidationRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<PendingValidationDto>> Handle(GetAllByUserIdQuery<PendingValidationDto> request, CancellationToken cancellationToken)
    {
        IEnumerable<PendingValidation> pendingEntity = await _repository.GetAllByUserIdAsync(request.userId);
        if (pendingEntity == null)
             throw new ArgumentNullException(nameof(request));
        
        return MapperLazyConf.Mapper.Map<IEnumerable<PendingValidation>, IEnumerable<PendingValidationDto>>(pendingEntity);
    }
}
