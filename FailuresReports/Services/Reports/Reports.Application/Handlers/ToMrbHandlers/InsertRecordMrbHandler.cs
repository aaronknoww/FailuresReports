using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.ToMrbHandlers;

public class InsertRecordMrbHandler : IRequestHandler<InsertRecordCommand<ToMrbDto>, bool>
{
    private readonly IToMrbRepository _repository;

    public InsertRecordMrbHandler(IToMrbRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> Handle(InsertRecordCommand<ToMrbDto> request, CancellationToken cancellationToken)
    {
        var mrbEntity = MapperLazyConf.Mapper.Map<ToMrb>(request.EntityDto);
        if (mrbEntity == null)
             throw new ArgumentException("");
        return await _repository.InsertRecordAsync(mrbEntity);      
       
    }
}
