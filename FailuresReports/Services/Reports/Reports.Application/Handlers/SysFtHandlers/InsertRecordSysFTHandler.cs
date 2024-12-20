using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
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
        var sysFtEntity = MapperLazyConf.Mapper.Map<FailureRegistrationSYSFT>(request.EntityDto);
        if (sysFtEntity == null)
             throw new ArgumentException("");
        return await _repository.InsertRecordAsync(sysFtEntity);
    }
}
