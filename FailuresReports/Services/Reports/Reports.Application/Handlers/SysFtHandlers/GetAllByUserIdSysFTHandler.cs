using System;
using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetAllByUserIdSysFTHandler : IRequestHandler<GetAllByUserIdQuery<FailureRegistrationSYSFTDto>, IEnumerable<FailureRegistrationSYSFTDto>>
{
    private readonly ISYSFTFailureRepository _repository;

    public GetAllByUserIdSysFTHandler(ISYSFTFailureRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<FailureRegistrationSYSFTDto>> Handle(GetAllByUserIdQuery<FailureRegistrationSYSFTDto> request, CancellationToken cancellationToken)
    {
        IEnumerable<FailureRegistrationSYSFT> sysftEntity = await _repository.GetAllByUserIdAsync(request.userId);
        //TODO: CREATE A CLASS FOR EXEPTIONS
        if (sysftEntity == null)
             throw new ArgumentNullException(nameof(request));
        
        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSFT>, IEnumerable<FailureRegistrationSYSFTDto>>(sysftEntity);

    }
}
