using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetFailureByTestStationSysVFHandler : IRequestHandler<GetFailureByTestStationSysQuery<FailureRegistrationSYSVFDto>, IEnumerable<FailureRegistrationSYSVFDto>>
{
    private readonly ISYSVFFailureRepository _repository;

    public GetFailureByTestStationSysVFHandler(ISYSVFFailureRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<FailureRegistrationSYSVFDto>> Handle(GetFailureByTestStationSysQuery<FailureRegistrationSYSVFDto> request, CancellationToken cancellationToken)
    {
        var sysvfEntity = await _repository.GetAllFailureByTestStationAsync(request.testStation);
        if (sysvfEntity == null)
             throw new EntityNotFoundException($"There are no failures registered by testStation number {request.testStation}");

        //TODO: generate logs if the operation fail or if is succesfull.
        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSVF>, IEnumerable<FailureRegistrationSYSVFDto>>(sysvfEntity);
    }
}

