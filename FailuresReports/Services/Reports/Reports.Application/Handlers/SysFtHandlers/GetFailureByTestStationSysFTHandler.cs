using Reports.Application.Dtos;
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
    public async Task<IEnumerable<FailureRegistrationSYSFTDto>> Handle(GetFailureByAreaSysQuery<FailureRegistrationSYSFTDto> request, CancellationToken cancellationToken)
    {
        var sysftEntity = await _repository.GetFailureByTestStation(request.testArea);
        if (sysftEntity == null)
             throw new ArgumentNullException(nameof(request));
        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSFT>, IEnumerable<FailureRegistrationSYSFTDto>>(sysftEntity);
    }
}

/*

    
    Task<IEnumerable<T>> GetFailureByTestStation(string testStation);
    Task<IEnumerable<T>> GetFailureByBu(string bu);
*/