using System;
using MediatR;
using Reports.Application.Dtos;
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
        var repo = await _repository.GetBySerialNumberAsync(request.SerialNumber);
        return MapperLazyConf.Mapper.Map<ToMrb, ToMrbDto>(repo);
    }
}
