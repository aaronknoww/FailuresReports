using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Common;
using Reports.Core.Entities;

namespace FailuresReports.Services.Reports.Reports.Application.Handlers.Common.Queries;

public class GetAllFailureByAreaSysHandler<TEntity, TDto> : IRequestHandler<GetAllFailureByAreaSysQuery<TDto>, IEnumerable<TDto>>
where TEntity : FailureRegistrationGeneric
where TDto : FailiureDtoGeneric
{
    private readonly IFailureCommonRepository<TEntity> _repository;

    public GetAllFailureByAreaSysHandler(IFailureCommonRepository<TEntity> repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<TDto>> Handle(GetAllFailureByAreaSysQuery<TDto> request, CancellationToken cancellationToken)
    {
        IEnumerable<TEntity> entities = await _repository.GetAllFailuresByAreaAsync(request.testArea, request.start, request.end, request.maxRows);
        if (entities == null || !entities.Any())
            //TODO CREATE A EXEPCTION
            throw new ArgumentException("");
            //TODO CREATE LOGS

         return MapperLazyConf.Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);

    }
}
