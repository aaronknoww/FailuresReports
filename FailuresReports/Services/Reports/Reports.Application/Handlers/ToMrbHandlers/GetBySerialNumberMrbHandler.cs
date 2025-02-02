using System;
using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.ToMrbHandlers;

public class GetBySerialNumberMrbHandler : IRequestHandler<GetBySerialNumberQuery<ToMrbDto>, ToMrbDto>
{
    private readonly IToMrbRepository _repository;

    public GetBySerialNumberMrbHandler(IToMrbRepository repository)
    {
        this._repository = repository;
    }
    public async Task<ToMrbDto> Handle(GetBySerialNumberQuery<ToMrbDto> request, CancellationToken cancellationToken)
    {
        ToMrb entity = await _repository.GetBySerialNumberAsync(request.SerialNumber);
        
        if (entity == null)
           throw new EntityNotFoundException($"There is no pending validation for this object. {nameof(ToMrb)} ", request.SerialNumber);
        //TODO: generate logs if the operation fail or if is succesfull.
        return MapperLazyConf.Mapper.Map<ToMrb, ToMrbDto>(entity);
    }
}


