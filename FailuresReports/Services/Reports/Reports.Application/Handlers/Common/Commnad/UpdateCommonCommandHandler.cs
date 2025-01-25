using MediatR;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Reports.Application.Commands;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Core.Common;

namespace Reports.Application.Handlers.Common.Commnad;

public class UpdateCommonCommandHandler<TEntity, TDto> : IRequestHandler<UpdateCommonCommand<TDto>, bool>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    private readonly IGenericRepository<TEntity> _repository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public UpdateCommonCommandHandler(IGenericRepository<TEntity> repository, ILogger logger, IMapper mapper)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this._logger = logger;
        this._mapper = mapper;
    }

    public async Task<bool> Handle(UpdateCommonCommand<TDto> request, CancellationToken cancellationToken)
    {
        //var entity = MapperLazyConf.Mapper.Map<TDto, TEntity>(request.EntityDto);
        var entity =  _mapper.Map<TDto, TEntity>(request.EntityDto);
        if(await _repository.UpdateAsync(entity))
        {
            _logger.LogInformation($"Successfully updated record for this Entity {nameof(request.EntityDto)}");
            return true;
        }
        else
        {
            _logger.LogError($"Some error has occurred trying to update this Entity {nameof(request.EntityDto)}");
            return false;
        }
    }
}
