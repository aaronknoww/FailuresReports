using AutoMapper;
using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Common;
using Microsoft.Extensions.Logging;

namespace Reports.Application.Handlers.Common;

public class GetAllValuesBySerialNumberCommonHandler<TEntity, TDto> : IRequestHandler<GetAllValuesBySerialNumberQuery<TDto>, IEnumerable<TDto>>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    private readonly IGenericRepository<TEntity> _repository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public GetAllValuesBySerialNumberCommonHandler(IGenericRepository<TEntity> repository, ILogger logger, IMapper mapper)
    {
        this._repository =  repository ?? throw new ArgumentNullException(nameof(repository));
        this._logger = logger;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<TDto>> Handle(GetAllValuesBySerialNumberQuery<TDto> request, CancellationToken cancellationToken)
    {
        IEnumerable<TEntity> entitie = await _repository.GetAllValuesBySerialNumberAsync(request.SerialNumber);
        if (entitie == null)
        {
            _logger.LogError($"There is not information related to this Serial Number {request.SerialNumber} ");
            throw new EntityNotFoundException(typeof(TEntity).Name, request.SerialNumber);
        }
        
        _logger.LogInformation($"Successfully fetched record for this Serial Number {request.SerialNumber}");

        // Map entities to DTOs.
        //return MapperLazyConf.Mapper.Map<TEntity, TDto>(entitie);
        return  _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entitie);
    }
}
