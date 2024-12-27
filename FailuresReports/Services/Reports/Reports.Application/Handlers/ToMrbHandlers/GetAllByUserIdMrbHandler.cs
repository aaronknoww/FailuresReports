using MediatR;
using Reports.Application.Dtos;
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
        IEnumerable<ToMrb> toMrbEntity = await _repository.GetAllByUserIdAsync(request.userId);
        //TODO: CREATE A CLASS FOR EXEPTIONS
        if (toMrbEntity == null)
             throw new ArgumentNullException(nameof(request));
        
        return MapperLazyConf.Mapper.Map<IEnumerable<ToMrb>, IEnumerable<ToMrbDto>>(toMrbEntity);

    }
}


