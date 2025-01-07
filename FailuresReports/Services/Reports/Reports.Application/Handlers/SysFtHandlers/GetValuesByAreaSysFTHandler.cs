using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetValuesByAreaSysFTHandler : IRequestHandler<GetFailureByAreaSysQuery<FailureRegistrationSYSFTDto>, IEnumerable<FailureRegistrationSYSFTDto>>
{
    private readonly ISYSFTFailureRepository _repository;

    public GetValuesByAreaSysFTHandler(ISYSFTFailureRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<FailureRegistrationSYSFTDto>> Handle(GetFailureByAreaSysQuery<FailureRegistrationSYSFTDto> request, CancellationToken cancellationToken)
    {
        //TODO: is necessary implement a date range and rows limt
        IEnumerable<FailureRegistrationSYSFT> sysftEntity = await _repository.GetAllFailuresByAreaAsync(request.testArea);
        if (sysftEntity == null || sysftEntity.Count() == 0)
             throw new EntityNotFoundException($"There are no failures registered by this test area {request.testArea}.");
        //TODO: generate logs if the operation fail or if is succesfull.
        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSFT>, IEnumerable<FailureRegistrationSYSFTDto>>(sysftEntity);
    }
}
