using System;
using MediatR;
using Reports.Application.Commands;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.PendingValidationHandlers;

public class UpdatePendingHandler : IRequestHandler<UpdateCommonCommand<PendingValidationDto>, bool>
{
    private readonly IPendingValidationRepository _repository;

    public UpdatePendingHandler(IPendingValidationRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> Handle(UpdateCommonCommand<PendingValidationDto> request, CancellationToken cancellationToken)
    {
        var pendingEntity = MapperLazyConf.Mapper.Map<PendingValidation>(request.EntityDto);
        
        //TODO: MAKE VALIDATION OF OBJECT.
        if (pendingEntity == null)
            throw new ArgumentException("");
        return await _repository.UpdateAsync(pendingEntity);
    }
}
