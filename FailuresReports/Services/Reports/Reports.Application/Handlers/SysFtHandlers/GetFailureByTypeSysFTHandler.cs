using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetFailureByTypeSysFTHandler : IRequestHandler<GetFailureByTypeSysQuery<FailureRegistrationSYSFTDto>, IEnumerable<FailureRegistrationSYSFTDto>>
{
    private readonly ISYSFTFailureRepository _repository;

    public GetFailureByTypeSysFTHandler(ISYSFTFailureRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<FailureRegistrationSYSFTDto>> Handle(GetFailureByTypeSysQuery<FailureRegistrationSYSFTDto> request, CancellationToken cancellationToken)
    {
        IEnumerable<FailureRegistrationSYSFT> sysftEntity = await _repository.GetAllFailureByTypeAsync(request.type);
        
        if (sysftEntity == null || sysftEntity.Count() == 0)
             throw new EntityNotFoundException($"There are no failures registered by this {request.type}.");
        //TODO: generate logs if the operation fail or if is succesfull.

        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSFT>, IEnumerable<FailureRegistrationSYSFTDto>>(sysftEntity);
    }
}

/*

    
    Task<IEnumerable<T>> GetFailureByTestStation(string testStation);
    Task<IEnumerable<T>> GetFailureByBu(string bu);
*/