using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Common;
using Reports.Core.Entities;

namespace FailuresReports.Services.Reports.Reports.Application.Handlers.Common.Queries;

public class GetFailureByTestStationSysCommonHandler<TEntity, TDto> : IRequestHandler<GetFailureByTestStationSysQuery<TDto>, IEnumerable<TDto>>
where TEntity : FailureRegistrationGeneric
where TDto : FailiureDtoGeneric
{
    private readonly IFailureCommonRepository<TEntity> _repository;

    public GetFailureByTestStationSysCommonHandler(IFailureCommonRepository<TEntity> repository)
    {
        this._repository = repository;
    }
    public async Task<IEnumerable<TDto>> Handle(GetFailureByTestStationSysQuery<TDto> request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllFailureByTestStationAsync(request.testStation, request.start, request.end, request.maxRows);
        if (entities == null && !entities.Any())
            //TODO CREATE A EXEPCTION
            throw new ArgumentException("");
            //TODO CREATE LOGS

         return MapperLazyConf.Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);
    }
}
