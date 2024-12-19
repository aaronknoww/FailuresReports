using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.PendingValidationHandlers;

public class DeleteBySerialnumberPendingHandler : IRequestHandler<DeleteBySerialnumberCommonCommand<PendingValidationDto>, bool>
{
    private readonly IPendingValidationRepository _repository;

    public DeleteBySerialnumberPendingHandler(IPendingValidationRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> Handle(DeleteBySerialnumberCommonCommand<PendingValidationDto> request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetBySerialNumberAsync(request.SerialNumber);
        //TODO: CREATE A CLASS FOR EXEPTIONS
        if (entity == null)
            throw new Exception("");
        return await _repository.DeleteBySerialnumberAsync(request.SerialNumber);
    }
}
