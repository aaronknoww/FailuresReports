using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Application.Handlers.Common.Queries;

public class GetAllFailureByTypeSysCommonHandler<TEntity, TDto> : IRequestHandler<GetAllFailureByTypeSysQuery<TDto>, IEnumerable<TDto>>
where TEntity : FailureRegistrationGeneric
where TDto : FailiureDtoGeneric
{
    private readonly IFailureCommonRepository<TEntity> _repository;

    public GetAllFailureByTypeSysCommonHandler(IFailureCommonRepository<TEntity> repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<TDto>> Handle(GetAllFailureByTypeSysQuery<TDto> request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllFailureByTypeAsync(request.type, request.start, request.end, request.maxRows);
         if (entities == null || !entities.Any())
            //TODO CREATE A EXEPCTION
            throw new ArgumentException("");
            //TODO CREATE LOGS

         return MapperLazyConf.Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);
    }
}
