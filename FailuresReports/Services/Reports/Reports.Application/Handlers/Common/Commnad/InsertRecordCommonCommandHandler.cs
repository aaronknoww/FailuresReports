using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Core.Common;
using AutoMapper;

namespace Reports.Application.Handlers.Common.Commnad;

public class InsertRecordCommonCommandHandler<TEntity, TDto> : IRequestHandler<InsertRecordCommand<TDto>, bool>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    private readonly IGenericRepository<TEntity> _repository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public InsertRecordCommonCommandHandler(IGenericRepository<TEntity> repository, ILogger logger, IMapper mapper)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this._logger = logger;
        this._mapper = mapper;
    }
    public async Task<bool> Handle(InsertRecordCommand<TDto> request, CancellationToken cancellationToken)
    {
        //var entity = MapperLazyConf.Mapper.Map<TDto, TEntity>(request.EntityDto);
        var entity = _mapper.Map<TDto, TEntity>(request.EntityDto);
        if(await _repository.InsertRecordAsync(entity))
        {
            _logger.LogInformation($"Successfully inserted the record for this Entity {nameof(request.EntityDto)}");
            return true;
        }
        else
        {
            _logger.LogError($"Some error has occurred with this Entity {nameof(request.EntityDto)}");
            return false;
        }
    }
}
