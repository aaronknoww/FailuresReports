using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.ToMrbQueries;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.ToMrbHandlers;

public class GetAllMrbHandler : IRequestHandler<GetAllMrbQuery, IEnumerable<ToMrbDto>>
{
    private readonly IToMrbRepository _repository;

    public GetAllMrbHandler(IToMrbRepository repository)
    {
        this._repository = repository;
    }
    public async Task<IEnumerable<ToMrbDto>> Handle(GetAllMrbQuery request, CancellationToken cancellationToken)
    {
        //TODO: is necessary implement a date range and rows limt
        var toMrbEntity = await _repository.GetAllMrbAsync();
        if (toMrbEntity == null || toMrbEntity.Count() == 0)
             throw new EntityNotFoundException($"There are units sended to MRB {nameof(request)}.");
        //TODO: generate logs if the operation fail or if is succesfull.
        return MapperLazyConf.Mapper.Map<IEnumerable<ToMrb>, IEnumerable<ToMrbDto>>(toMrbEntity);        
        
    }
}
