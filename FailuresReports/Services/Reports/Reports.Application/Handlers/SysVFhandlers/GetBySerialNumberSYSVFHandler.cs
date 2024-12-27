using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetBySerialNumberSYSVFHandler : IRequestHandler<GetBySerialNumberQuery<FailureRegistrationSYSVFDto>, FailureRegistrationSYSVFDto>
{
    private readonly ISYSVFFailureRepository _repository;

    public GetBySerialNumberSYSVFHandler(ISYSVFFailureRepository repository)
    {
        this._repository = repository;
    }
    public async Task<FailureRegistrationSYSVFDto> Handle(GetBySerialNumberQuery<FailureRegistrationSYSVFDto> request, CancellationToken cancellationToken)
    {
        FailureRegistrationSYSVF SysftRepo = await _repository.GetBySerialNumberAsync(request.SerialNumber);
        //TODO: CREATE A CLASS FOR EXEPTIONS
        if (SysftRepo == null)
            throw new ArgumentNullException(nameof(request));
        
        var SysftDto = MapperLazyConf.Mapper.Map<FailureRegistrationSYSVF, FailureRegistrationSYSVFDto>(SysftRepo);
        return SysftDto;
    }
}
