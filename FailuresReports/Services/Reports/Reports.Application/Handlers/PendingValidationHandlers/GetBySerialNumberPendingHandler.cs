using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.PendingValidationHandlers;

public class GetBySerialNumberPendingHandler : IRequestHandler<GetBySerialNumberQuery<PendingValidationDto>, PendingValidationDto>
{
    private readonly IPendingValidationRepository _repository;

    public GetBySerialNumberPendingHandler(IPendingValidationRepository repository)
    {
        this._repository = repository;
    }
    public async Task<PendingValidationDto> Handle(GetBySerialNumberQuery<PendingValidationDto> request, CancellationToken cancellationToken)
    {
        PendingValidation entity = await _repository.GetBySerialNumberAsync(request.SerialNumber);
        //TODO: CREATE A CLASS FOR EXEPTIONS
        if (entity == null)
           throw new EntityNotFoundException($"There is no pending validation for this object. {nameof(PendingValidation)} ", request.SerialNumber);
        //TODO: generate logs if the operation fail or if is succesfull.
        return MapperLazyConf.Mapper.Map<PendingValidation, PendingValidationDto>(entity);
        
    }
}
