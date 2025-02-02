using MediatR;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Application.Querys.Common;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.ToMrbHandlers;

public class GetAllByUserIdMrbHandler : IRequestHandler<GetAllByUserIdQuery<ToMrbDto>, IEnumerable<ToMrbDto>>
{
    private readonly IToMrbRepository _repository;

    public GetAllByUserIdMrbHandler(IToMrbRepository repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task<IEnumerable<ToMrbDto>> Handle(GetAllByUserIdQuery<ToMrbDto> request, CancellationToken cancellationToken)
    {
        //TODO: is necessary implement a date range and rows limt
        IEnumerable<ToMrb> toMrbEntity = await _repository.GetAllByUserIdAsync(request.userId);
        if (toMrbEntity == null || toMrbEntity.Count() == 0)
             throw new EntityNotFoundException(nameof(PendingValidation), request.userId);
        
        //TODO: explain in the logs what happend with the operation
        
        return MapperLazyConf.Mapper.Map<IEnumerable<ToMrb>, IEnumerable<ToMrbDto>>(toMrbEntity);

    }
}


