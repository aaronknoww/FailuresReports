using MediatR;
using Reports.Application.Commands;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysVFhandlers;

public class UpdateSysVFHandler : IRequestHandler<UpdateCommonCommand<FailureRegistrationSYSVFDto>, bool>
{
    private readonly ISYSVFFailureRepository _repository;

    UpdateSysVFHandler(ISYSVFFailureRepository repository)
    {
        this._repository = repository;
    }

    public async Task<bool> Handle(UpdateCommonCommand<FailureRegistrationSYSVFDto> request, CancellationToken cancellationToken)
    {
        if( request.EntityDto == null )
            throw new EntityNotFoundException($"There is no failur to update. {nameof(request.EntityDto)}");
        var failuresSysVFEntity = MapperLazyConf.Mapper.Map<FailureRegistrationSYSVF>(request.EntityDto);
        if (failuresSysVFEntity == null)
            throw new ArgumentException("");
        //TODO: CHECK OBJECT
        return await _repository.UpdateAsync(failuresSysVFEntity);
    }
}
