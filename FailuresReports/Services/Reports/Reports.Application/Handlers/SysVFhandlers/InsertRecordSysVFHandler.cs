using System;
using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysVFhandlers;

public class InsertRecordSysVFHandler : IRequestHandler<InsertRecordCommand<FailureRegistrationSYSVFDto>, bool>
{
    private readonly ISYSVFFailureRepository _repository;

    public InsertRecordSysVFHandler(ISYSVFFailureRepository _repository)
    {
        this._repository = _repository;
    }
    public async Task<bool> Handle(InsertRecordCommand<FailureRegistrationSYSVFDto> request, CancellationToken cancellationToken)
    {
        if( request.EntityDto == null)
            throw new EntityNotFoundException($"There is no failur to be inserted {nameof(request.EntityDto)}.");
        
        //TODO: Validator for entity dto.
        //TODO: creat logs
        var sysVFEntity = MapperLazyConf.Mapper.Map<FailureRegistrationSYSVF>(request.EntityDto);
        return await _repository.InsertRecordAsync(sysVFEntity);
    }
}
