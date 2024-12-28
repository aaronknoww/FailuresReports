using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetFailureByTestStationSysFTHandler : IRequestHandler<GetFailureByTestStationSysQuery<FailureRegistrationSYSFTDto>, IEnumerable<FailureRegistrationSYSFTDto>>
{
    private readonly ISYSFTFailureRepository _repository;

    public GetFailureByTestStationSysFTHandler(ISYSFTFailureRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<FailureRegistrationSYSFTDto>> Handle(GetFailureByTestStationSysQuery<FailureRegistrationSYSFTDto> request, CancellationToken cancellationToken)
    {
        IEnumerable<FailureRegistrationSYSFT> sysftEntity = await _repository.GetAllFailureByTestStationAsync(request.testStation);
        if (sysftEntity == null)
             throw new EntityNotFoundException($"There are no failures registered by testStation number {request.testStation}");

        //TODO: generate logs if the operation fail or if is succesfull.
        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSFT>, IEnumerable<FailureRegistrationSYSFTDto>>(sysftEntity);
    }
}
