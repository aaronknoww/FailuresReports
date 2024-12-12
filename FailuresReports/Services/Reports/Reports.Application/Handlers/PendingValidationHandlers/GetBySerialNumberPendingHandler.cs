using MediatR;
using Reports.Application.Dtos;
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
        if (entity == null)
           throw new Exception("No hay informacion de ese numero de serie");
        
        return MapperLazyConf.Mapper.Map<PendingValidation, PendingValidationDto>(entity);
        
    }
}
