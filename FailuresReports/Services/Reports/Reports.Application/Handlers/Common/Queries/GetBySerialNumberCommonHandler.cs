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

    public GetBySerialNumberCommonHandler(IGenericRepository<TEntity> repository)
    {
        this._repository =  repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<TDto> Handle(GetBySerialNumberQuery<TDto> request, CancellationToken cancellationToken)
    {
        TEntity entitie = await _repository.GetBySerialNumberAsync(request.SerialNumber);
        if (entitie == null)
            throw new EntityNotFoundException(typeof(TEntity).Name, request.SerialNumber);
        
        //Console.WriteLine($"Successfully fetched {entitie.Count()} records for userId {request.userId}.");

        // Map entities to DTOs.
        return MapperLazyConf.Mapper.Map<TEntity, TDto>(entitie);
    }
}
