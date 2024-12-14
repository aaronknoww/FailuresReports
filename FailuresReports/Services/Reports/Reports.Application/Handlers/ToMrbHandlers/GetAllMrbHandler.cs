using MediatR;
using Reports.Application.Dtos;
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
        var toMrbEntity = await _repository.GetAllMrbAsync();
        if(toMrbEntity == null)
            throw new ArgumentNullException(nameof(request));
        return MapperLazyConf.Mapper.Map<IEnumerable<ToMrb>, IEnumerable<ToMrbDto>>(toMrbEntity);        
        
    }
}
