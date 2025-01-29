using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Querys.Common;
using Reports.Core.Common;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Reports.Application.Handlers.Common;

public class GetAllByUserIdGenericHandler<TEntity, TDto> : IRequestHandler<GetAllByUserIdQuery<TDto>, IEnumerable<TDto>>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    private readonly IGenericRepository<TEntity> _repository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public GetAllByUserIdGenericHandler(IGenericRepository<TEntity> repository, ILogger logger, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this._logger = logger;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<TDto>> Handle(GetAllByUserIdQuery<TDto> request, CancellationToken cancellationToken)
    {
        // Fetch entities from the repository.
        IEnumerable<TEntity> entities = await _repository.GetAllValuesByUserIdAsync(request.userId, request.start, request.end, request.maxRows);
        if (entities == null || !entities.Any())
        {
            _logger.LogError($"There is not information related to this user {request.userId}, and this start date {request.start} and end date {request.end}");
            throw new EntityNotFoundException(typeof(TEntity).Name, request.userId);
        }

        _logger.LogInformation($"Successfully fetched {entities.Count()} records for userId {request.userId}.");
    
        // Map entities to DTOs.
        return  _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);
    }
}
