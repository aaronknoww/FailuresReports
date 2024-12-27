using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Core.Entities;
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
        PendingValidation entity = await _repository.GetBySerialNumberAsync(request.SerialNumber);
        //TODO: Logs about failiure.
        if (entity == null)
            throw new EntityNotFoundException(nameof(PendingValidation), request.SerialNumber);
        return await _repository.DeleteBySerialnumberAsync(request.SerialNumber);
    }
}
