using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Common;

namespace Reports.Application.Handlers.Common.Queries;

public class GetAllValuesByDateCommonHandler<TEntity, TDto> : IRequestHandler<GetAllValuesByDateQuery<TDto>, IEnumerable<TDto>>
where TEntity : BaseEntity
where TDto : BaseDto
{
    private readonly IGenericRepository<TEntity> _repository;

    public GetAllValuesByDateCommonHandler(IGenericRepository<TEntity> repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<TDto>> Handle(GetAllValuesByDateQuery<TDto> request, CancellationToken cancellationToken)
    {
        IEnumerable<TEntity> entities = await _repository.GetAllValuesByDateAsync(request.start, request.end, request.maxRows);

        if (entities == null || !entities.Any())
            //TODO CREATE A EXEPCTION
            throw new ArgumentException("");
            //TODO CREATE LOGS

         return MapperLazyConf.Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);
    }
}
