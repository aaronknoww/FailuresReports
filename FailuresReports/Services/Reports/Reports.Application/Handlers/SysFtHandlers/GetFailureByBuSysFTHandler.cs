using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetFailureByBuSysFTHandler : IRequestHandler<GetFailureByBuSysQuery<FailureRegistrationSYSFTDto>, IEnumerable<FailureRegistrationSYSFTDto>>
{
    private readonly ISYSFTFailureRepository _repository;

    public GetFailureByBuSysFTHandler(ISYSFTFailureRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<FailureRegistrationSYSFTDto>> Handle(GetFailureByBuSysQuery<FailureRegistrationSYSFTDto> request, CancellationToken cancellationToken)
    {
        IEnumerable<FailureRegistrationSYSFT> sysftEntity = await _repository.GetAllFailuresByBuAsync(request.bu);
        if (sysftEntity == null || sysftEntity.Count() == 0)
             throw new EntityNotFoundException($"There are no failures registered in this BU number {request.bu} ");
        //TODO: generate logs if the operation fail or if is succesfull.

        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSFT>, IEnumerable<FailureRegistrationSYSFTDto>>(sysftEntity);
    }
}
