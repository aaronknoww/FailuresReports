using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetBySerialNumberSYSFTHandler : IRequestHandler<GetBySerialNumberQuery<FailureRegistrationSYSFTDto>, FailureRegistrationSYSFTDto>
{
    private readonly ISYSFTFailureRepository _repository;

    public GetBySerialNumberSYSFTHandler(ISYSFTFailureRepository repository)
    {
        this._repository = repository;
    }
    public async Task<FailureRegistrationSYSFTDto> Handle(GetBySerialNumberQuery <FailureRegistrationSYSFTDto> request, CancellationToken cancellationToken)
    {
        //TODO: CHECK IF ONE SERIAL NUMBER ONLY COULD HAVE MORE THEN ONE FAILURE REGISTER
        FailureRegistrationSYSFT SysftRepo = await _repository.GetBySerialNumberAsync(request.SerialNumber);
        //TODO: CREATE A CLASS FOR EXEPTIONS
        if (SysftRepo == null)
             throw new ArgumentNullException(nameof(request));
             
        FailureRegistrationSYSFTDto SysftDto = MapperLazyConf.Mapper.Map<FailureRegistrationSYSFT, FailureRegistrationSYSFTDto>(SysftRepo);
        return SysftDto;
    }
}
