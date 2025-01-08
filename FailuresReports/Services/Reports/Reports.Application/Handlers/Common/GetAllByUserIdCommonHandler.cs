using MediatR;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Common;

namespace Reports.Application.Handlers.Common;

public class GetAllByUserIdGenericHandler<TEntity, TDto> : IRequestHandler<GetAllByUserIdQuery<TDto>, IEnumerable<TDto>>
    where TEntity : class
    where TDto : class
{
    private readonly IGenericRepository<TEntity> _repository;

    public GetAllByUserIdGenericHandler(IGenericRepository<TEntity> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<IEnumerable<TDto>> Handle(GetAllByUserIdQuery<TDto> request, CancellationToken cancellationToken)
    {
        // Fetch entities from the repository.
        IEnumerable<TEntity> entities = await _repository.GetAllByUserIdAsync(request.userId, request.start, request.end, request.maxRows);
        if (entities == null || !entities.Any())
            throw new EntityNotFoundException(typeof(TEntity).Name, request.userId);

        // Log the operation (optional).
        Console.WriteLine($"Successfully fetched {entities.Count()} records for userId {request.userId}.");

        // Map entities to DTOs.
        return MapperLazyConf.Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);
    }
}
