using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class GetValuesByDateSysVFHandler : IRequestHandler<GetAllByUserIdQuery<FailureRegistrationSYSVFDto>, IEnumerable<FailureRegistrationSYSVFDto>>
{
    private readonly ISYSVFFailureRepository _repository;

    public GetValuesByDateSysVFHandler(ISYSVFFailureRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<FailureRegistrationSYSVFDto>> Handle(GetAllByUserIdQuery<FailureRegistrationSYSVFDto> request, CancellationToken cancellationToken)
    {
        IEnumerable<FailureRegistrationSYSVF> sysvfEntity = await _repository.GetAllByUserIdAsync(request.userId);
        if (sysvfEntity == null || sysvfEntity.Count() == 0)
             throw new EntityNotFoundException($"There are no failures registered between  {request.Start} and {request.End}.");
        //TODO: generate logs if the operation fail or if is succesfull.
        
        return MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSVF>, IEnumerable<FailureRegistrationSYSVFDto>>(sysvfEntity);

    }
}
