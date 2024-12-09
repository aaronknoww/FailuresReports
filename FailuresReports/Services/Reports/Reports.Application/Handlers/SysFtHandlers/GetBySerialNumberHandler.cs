using System;
using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.SysFtQueries;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetBySerialNumberHandler : IRequestHandler<GetBySerialNumberQuery, FailureRegistrationSYSFTDto>
{
    private readonly ISYSFTFailureRepository _repository;

    public GetBySerialNumberHandler(ISYSFTFailureRepository repository)
    {
        this._repository = repository;
    }
    public async Task<FailureRegistrationSYSFTDto> Handle(GetBySerialNumberQuery request, CancellationToken cancellationToken)
    {
        FailureRegistrationSYSFT SysftRepo = await _repository.GetBySerialNumberAsync(request.SerialNumber);
        FailureRegistrationSYSFTDto SysftDto = MapperLazyConf.Mapper.Map<FailureRegistrationSYSFT, FailureRegistrationSYSFTDto>(SysftRepo);
        return SysftDto;
    }
}
