using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.ToMrbHandlers;

public class GetValuesByDateMrbHandler : IRequestHandler<GetValuesByDateQuery<ToMrbDto>, IEnumerable<ToMrbDto>>
{
    private readonly IToMrbRepository _repository;

    public GetValuesByDateMrbHandler(IToMrbRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<ToMrbDto>> Handle(GetValuesByDateQuery<ToMrbDto> request, CancellationToken cancellationToken)
    {
        //TODO: rows limt and show more rescentlies first
        IEnumerable<ToMrb> toMrbEntity = await _repository.GetValuesByDateAsync(request.Start, request.End);
        if (toMrbEntity == null || toMrbEntity.Count() == 0)
             throw new EntityNotFoundException($"There is no pending validation {nameof(PendingValidation)}", request);
        //TODO: generate logs if the operation fail or if is succesfull.
        
        return MapperLazyConf.Mapper.Map<IEnumerable<ToMrb>, IEnumerable<ToMrbDto>>(toMrbEntity);

    }
}


