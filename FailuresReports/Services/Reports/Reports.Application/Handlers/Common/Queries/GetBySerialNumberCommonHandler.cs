using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Common;

namespace Reports.Application.Handlers.Common;

public class GetBySerialNumberCommonHandler<TEntity, TDto> : IRequestHandler<GetBySerialNumberQuery<TDto>, TDto>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    private readonly IGenericRepository<TEntity> _repository;
    private readonly ILogger _logger;

    public GetBySerialNumberCommonHandler(IGenericRepository<TEntity> repository, ILogger logger)
    {
        this._repository =  repository ?? throw new ArgumentNullException(nameof(repository));
        this._logger = logger;
    }

    public async Task<TDto> Handle(GetBySerialNumberQuery<TDto> request, CancellationToken cancellationToken)
    {
        TEntity entitie = await _repository.GetBySerialNumberAsync(request.SerialNumber);
        if (entitie == null)
        {
            _logger.LogError($"There is not information related to this Serial Number {request.SerialNumber} ");
            throw new EntityNotFoundException(typeof(TEntity).Name, request.SerialNumber);
        }
        
        _logger.LogInformation($"Successfully fetched record for this Serial Number {request.SerialNumber}");

        // Map entities to DTOs.
        return MapperLazyConf.Mapper.Map<TEntity, TDto>(entitie);
    }
}
