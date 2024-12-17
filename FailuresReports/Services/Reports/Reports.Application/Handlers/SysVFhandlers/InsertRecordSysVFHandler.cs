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
        var sysVFEntity = MapperLazyConf.Mapper.Map<FailureRegistrationSYSVF>(request.EntityDto);
        if (sysVFEntity == null)
             throw new ArgumentException("");
        return await _repository.InsertRecord(sysVFEntity);
    }
}
