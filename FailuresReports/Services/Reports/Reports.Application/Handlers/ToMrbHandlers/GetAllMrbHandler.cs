using MediatR;
using Microsoft.Extensions.Logging;
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
    private readonly ILogger _logger;

    public GetAllMrbHandler(IToMrbRepository repository, ILogger logger)
    {
        this._repository = repository;
        this._logger = logger;
    }
    public async Task<IEnumerable<ToMrbDto>> Handle(GetAllMrbQuery request, CancellationToken cancellationToken)
    {
        //TODO: CHECK IF THIS CLASS IS NECESARY DUE TO EXIST GETALLVALUESBYDATE.

        IEnumerable<ToMrb> toMrbEntity = await _repository.GetAllMrbAsync(request.start, request.end, request.maxRows);
         if (toMrbEntity == null || !toMrbEntity.Any())
        {
            _logger.LogError($"There is not information between start date {request.start} and end date {request.end}");
            throw new RegistersNotFoundException("There is a null entity or not exist registers in DB");
        }
        _logger.LogInformation($"Successfully fetched {toMrbEntity.Count()} records between the start date {request.start} and end date {request.end}");

        return MapperLazyConf.Mapper.Map<IEnumerable<ToMrb>, IEnumerable<ToMrbDto>>(toMrbEntity);        
        
    }
}
