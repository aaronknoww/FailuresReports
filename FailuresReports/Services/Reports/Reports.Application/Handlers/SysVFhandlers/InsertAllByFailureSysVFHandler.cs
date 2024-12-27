using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysVFhandlers;

public class InsertAllByFailureSysVFHandler : IRequestHandler<InsertAllByFailiureCommonCommand<FailureRegistrationSYSVFDto>, bool>
{
    private readonly ISYSVFFailureRepository _repository;

    public InsertAllByFailureSysVFHandler(ISYSVFFailureRepository repository)
    {
        this._repository = repository;
    }

    public async Task<bool> Handle(InsertAllByFailiureCommonCommand<FailureRegistrationSYSVFDto> request, CancellationToken cancellationToken)
    {
        //TODO: check if is necessary a try and catch block
        IEnumerable<FailureRegistrationSYSVF> sysVFFailures = MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSVF>>(request.FailuresDto);
        return await _repository.InsertAllByFailure(sysVFFailures);
    }
}
