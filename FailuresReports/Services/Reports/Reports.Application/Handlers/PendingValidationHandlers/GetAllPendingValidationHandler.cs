using MediatR;
using Microsoft.Extensions.Logging;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.PendingValidationQueries;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.PendingValidationHandlers;

public class GetAllPendingValidationHandler : IRequestHandler<GetAllPendingValidationQuery, IEnumerable<PendingValidationDto>>
{
    private readonly IPendingValidationRepository _repository;
    private readonly ILogger _logger;

    public GetAllPendingValidationHandler(IPendingValidationRepository repository, ILogger logger)
    {
        this._repository = repository;
        this._logger = logger;
    }

    public async Task<IEnumerable<PendingValidationDto>> Handle(GetAllPendingValidationQuery request, CancellationToken cancellationToken)
    {
        //TODO: CHECK IF THIS CLASS IS NECESSARY DUE TO GETALLBYDATE.
        
        IEnumerable<PendingValidation> pendingEntity = await _repository.GetAllPendingValidationAsync(request.start, request.end, request.maxRows);

         if (pendingEntity == null || !pendingEntity.Any())
        {
            _logger.LogError($"There is not information between start date {request.start} and end date {request.end}");
            throw new RegistersNotFoundException("There is a null entity or not exist registers in DB");
        }
        _logger.LogInformation($"Successfully fetched {pendingEntity.Count()} records between the start date {request.start} and end date {request.end}");

       
        return MapperLazyConf.Mapper.Map<IEnumerable<PendingValidation>, IEnumerable<PendingValidationDto>>(pendingEntity);
    }
}
