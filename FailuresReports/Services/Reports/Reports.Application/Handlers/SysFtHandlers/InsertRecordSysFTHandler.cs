using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Application.Mappers;
using Reports.Core.Entities;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class InsertRecordSysFTHandler : IRequestHandler<InsertRecordCommand<FailureRegistrationSYSFTDto>, bool>
{
    private readonly ISYSFTFailureRepository _repository;

    public InsertRecordSysFTHandler(ISYSFTFailureRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> Handle(InsertRecordCommand<FailureRegistrationSYSFTDto> request, CancellationToken cancellationToken)
    {
        if( request.EntityDto == null)
            throw new EntityNotFoundException($"There is no failur to be inserted {nameof(request.EntityDto)}.");
        
        //TODO: Validator for entity dto.
        //TODO: creat logs.
        var sysFtEntity = MapperLazyConf.Mapper.Map<FailureRegistrationSYSFT>(request.EntityDto);
        //TODO: CREATE A CLASS FOR EXEPTIONS
        return await _repository.InsertRecordAsync(sysFtEntity);
    }
}
