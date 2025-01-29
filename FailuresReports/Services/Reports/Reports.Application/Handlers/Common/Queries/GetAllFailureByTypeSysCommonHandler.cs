using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Querys.Common;
using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Application.Handlers.Common.Queries;

public class GetAllFailureByTypeSysCommonHandler<TEntity, TDto> : IRequestHandler<GetAllFailureByTypeSysQuery<TDto>, IEnumerable<TDto>>
where TEntity : FailureRegistrationGeneric
where TDto : FailiureDtoGeneric
{
    private readonly IFailureCommonRepository<TEntity> _repository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public GetAllFailureByTypeSysCommonHandler(IFailureCommonRepository<TEntity> repository, ILogger logger, IMapper mapper)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this._logger = logger;
        this._mapper = mapper;
    }
    public async Task<IEnumerable<TDto>> Handle(GetAllFailureByTypeSysQuery<TDto> request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllFailureByTypeAsync(request.type, request.start, request.end, request.maxRows);
        if (entities == null || !entities.Any())
        {
            _logger.LogError($"There is not information related to about that type of failure {request.type}, and this start date {request.start} and end date {request.end}");
            throw new RegistersNotFoundException("There is a null entity or not exist registers in DB");
        }
        _logger.LogInformation($"Successfully fetched {entities.Count()} records for this type of failiure {request.type}");

         return  _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);
    }
}
