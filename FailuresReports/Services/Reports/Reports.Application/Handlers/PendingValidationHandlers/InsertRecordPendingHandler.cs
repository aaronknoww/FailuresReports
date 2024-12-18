using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.PendingValidationHandlers;

public class InsertRecordPendingHandler : IRequestHandler<InsertRecordCommand<PendingValidationDto>, bool>
{
    private readonly IPendingValidationRepository _repository;

    public InsertRecordPendingHandler(IPendingValidationRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> Handle(InsertRecordCommand<PendingValidationDto> request, CancellationToken cancellationToken)
    {
        PendingValidation pendingEntity = MapperLazyConf.Mapper.Map<PendingValidation>(request.EntityDto);
        if (pendingEntity == null)
            throw new ArgumentException("");
        return await _repository.InsertRecordAsync(pendingEntity);
        
    }
}
