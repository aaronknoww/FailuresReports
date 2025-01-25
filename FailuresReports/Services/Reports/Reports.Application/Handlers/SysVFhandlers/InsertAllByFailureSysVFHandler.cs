using AutoMapper;
using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysVFhandlers;

public class InsertAllByFailureSysVFHandler : IRequestHandler<InsertAllByFailiureCommonCommand<FailureRegistrationSYSVFDto>, bool>
{
    //TODO: Finish this class with logs and check validators.
    private readonly ISYSVFFailureRepository _repository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public InsertAllByFailureSysVFHandler(ISYSVFFailureRepository repository, ILogger logger, IMapper mapper)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this._logger = logger;
        this._mapper = mapper;
    }

    public async Task<bool> Handle(InsertAllByFailiureCommonCommand<FailureRegistrationSYSVFDto> request, CancellationToken cancellationToken)
    {
        IEnumerable<FailureRegistrationSYSVF> sysVFFailures =  _mapper.Map<IEnumerable<FailureRegistrationSYSVF>>(request.FailuresDto);
        return await _repository.InsertAllByFailure(sysVFFailures);
    }
}
