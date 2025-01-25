using AutoMapper;
using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Common;

namespace Reports.Application.Handlers.Common.Queries;

public class GetAllValuesByDateCommonHandler<TEntity, TDto> : IRequestHandler<GetAllValuesByDateQuery<TDto>, IEnumerable<TDto>>
where TEntity : BaseEntity
where TDto : BaseDto
{
    private readonly IGenericRepository<TEntity> _repository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public GetAllValuesByDateCommonHandler(IGenericRepository<TEntity> repository, ILogger logger, IMapper mapper)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this._logger = logger;
        this._mapper = mapper;
    }
    public async Task<IEnumerable<TDto>> Handle(GetAllValuesByDateQuery<TDto> request, CancellationToken cancellationToken)
    {
        IEnumerable<TEntity> entities = await _repository.GetAllValuesByDateAsync(request.start, request.end, request.maxRows);

        if (entities == null || !entities.Any())
        {
            _logger.LogError($"There is not information between start date {request.start} and end date {request.end}");
            throw new RegistersNotFoundException("There is a null entity or not exist registers in DB");
        }
        _logger.LogInformation($"Successfully fetched {entities.Count()} records between the start date {request.start} and end date {request.end}");

         return  _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);
    }
}
