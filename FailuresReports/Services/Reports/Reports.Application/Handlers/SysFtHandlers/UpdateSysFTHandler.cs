using MediatR;
using Reports.Application.Commands;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class UpdateSysFTHandler : IRequestHandler<UpdateCommonCommand<FailureRegistrationSYSFTDto>, bool>
{
    private readonly ISYSFTFailureRepository _repository;

    public UpdateSysFTHandler(ISYSFTFailureRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> Handle(UpdateCommonCommand<FailureRegistrationSYSFTDto> request, CancellationToken cancellationToken)
    {
        if( request.EntityDto == null )
            throw new EntityNotFoundException($"There is no failur to update. {nameof(request.EntityDto)}");
        var failureSysFTEntity = MapperLazyConf.Mapper.Map<FailureRegistrationSYSFT>(request.EntityDto);
        //TODO: Object validation
        //TODO: create logs
        if(failureSysFTEntity == null)
            throw new ArgumentException("");
        
        return await _repository.UpdateAsync(failureSysFTEntity);
    }
}
