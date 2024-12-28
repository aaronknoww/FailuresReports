using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class InsertByFailureSysFTHandler : IRequestHandler<InsertAllByFailiureCommonCommand<FailureRegistrationSYSFTDto>, bool>
{
    private readonly ISYSFTFailureRepository _repository;

    public InsertByFailureSysFTHandler(ISYSFTFailureRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> Handle(InsertAllByFailiureCommonCommand<FailureRegistrationSYSFTDto> request, CancellationToken cancellationToken)
    {
        if( request.FailuresDto == null || request.FailuresDto.Count() == 0)
            throw new EntityNotFoundException($"There are no failures to be inserted.");
        
        //This function only gonna get Failures that are already in a DB
        //TODO: Validator to check objects to be inserted

        //TODO: CHECK IF TRY AND CATCH IS NECESSARY
        IEnumerable<FailureRegistrationSYSFT> failuresSysFT = MapperLazyConf.Mapper.Map<IEnumerable<FailureRegistrationSYSFT>>(request.FailuresDto);
        return await _repository.InsertAllByFailure(failuresSysFT);
    }
}
