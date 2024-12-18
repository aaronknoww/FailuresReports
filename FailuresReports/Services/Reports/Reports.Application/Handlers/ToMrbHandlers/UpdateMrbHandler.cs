using System;
using MediatR;
using Reports.Application.Commands;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.ToMrbHandlers;

public class UpdateMrbHandler : IRequestHandler<UpdateCommonCommand<ToMrbDto>, bool>
{
    private readonly IToMrbRepository _repository;

    public UpdateMrbHandler(IToMrbRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> Handle(UpdateCommonCommand<ToMrbDto> request, CancellationToken cancellationToken)
    {
        var mrbEntity = MapperLazyConf.Mapper.Map<ToMrb>(request.EntityDto);
        if (mrbEntity == null)
            throw new ArgumentException("");
        // TODO: CHECK OBJECT
        return await _repository.UpdateAsync(mrbEntity);
        
    }
}
