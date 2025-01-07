using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetValuesByDateSysFTHandler : IRequestHandler<GetValuesByDateQuery<FailureRegistrationSYSFTDto>, IEnumerable<FailureRegistrationSYSFTDto>>
{
    private readonly ISYSFTFailureRepository _repository;

    public GetValuesByDateSysFTHandler(ISYSFTFailureRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<FailureRegistrationSYSFTDto>> Handle(GetValuesByDateQuery<FailureRegistrationSYSFTDto> request, CancellationToken cancellationToken)
    {
        //TODO: IMPLEMENT ROWS LIMIT SHOW MORE RECIENT DATE FIRST
        var sysftEntity = await _repository.GetValuesByDateAsync(request.Start, request.End);
        if (sysftEntity == null || sysftEntity.Count() == 0)
             throw new EntityNotFoundException($"There are no failures registered between  {request.Start} and {request.End}.");
        //TODO: generate logs if the operation fail or if is succesfull.
        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSFT>, IEnumerable<FailureRegistrationSYSFTDto>>(sysftEntity);
    }
}

