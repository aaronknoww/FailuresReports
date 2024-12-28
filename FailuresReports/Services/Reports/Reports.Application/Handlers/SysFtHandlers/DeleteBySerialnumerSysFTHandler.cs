using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysFtHandlers;

public class DeleteBySerialnumerSysFTHandler : IRequestHandler<DeleteBySerialnumberCommonCommand<FailureRegistrationSYSFTDto>, bool>
{
    private readonly ISYSFTFailureRepository _repository;

    public DeleteBySerialnumerSysFTHandler(ISYSFTFailureRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> Handle(DeleteBySerialnumberCommonCommand<FailureRegistrationSYSFTDto> request, CancellationToken cancellationToken)
    {
        var sysFtEntity = await _repository.GetBySerialNumberAsync(request.SerialNumber);
        if (sysFtEntity == null)
            throw new EntityNotFoundException($"There is no failure associated with this serial number {request.SerialNumber}");
        
        //TODO: generate logs if the operation fail or if is succesfull.
        return await _repository.DeleteBySerialnumberAsync(request.SerialNumber);
    }
}
