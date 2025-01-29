using AutoMapper;
using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Querys.Common;
using Reports.Core.Common;
using Reports.Core.Entities;
using Microsoft.Extensions.Logging;

namespace FailuresReports.Services.Reports.Reports.Application.Handlers.Common.Queries;

public class GetAllFailureByBuSysCommonHandler<TEntity, TDto> : IRequestHandler<GetAllFailureByBuSysQuery<TDto>, IEnumerable<TDto>>
where TEntity : FailureRegistrationGeneric
where TDto : FailiureDtoGeneric
{
    private readonly IFailureCommonRepository<TEntity> _repository;
    private readonly ILogger<GetAllFailureByBuSysCommonHandler<TEntity, TDto>> _logger;
    private readonly IMapper _mapper;

    public GetAllFailureByBuSysCommonHandler(
        IFailureCommonRepository<TEntity> repository,
        ILogger<GetAllFailureByBuSysCommonHandler<TEntity, TDto>> logger,
        IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TDto>> Handle(GetAllFailureByBuSysQuery<TDto> request, CancellationToken cancellationToken)
    {
        IEnumerable<TEntity> entities = await _repository.GetAllFailuresByBuAsync(request.bu, request.start, request.end, request.maxRows);

        if (entities == null || !entities.Any())
        {
            _logger.LogError($"There is no information related to BU {request.bu}, start date {request.start}, and end date {request.end}.");
            throw new RegistersNotFoundException("There is a null entity or no registers in the database.");
        }
        _logger.LogInformation($"Successfully fetched {entities.Count()} records for BU {request.bu}.");

        return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);
    }
}
