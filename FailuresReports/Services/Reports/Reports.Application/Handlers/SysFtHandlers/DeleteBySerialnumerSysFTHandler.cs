using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
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
        //TODO: IMPLEMENT A CUSTOM EXECPTION CLASS
        if (sysFtEntity == null)
            throw new NotImplementedException();
        return await _repository.DeleteBySerialnumberAsync(request.SerialNumber);
    }
}
