using System;
using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Application.Exceptions;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.ToMrbHandlers;

public class DeleteBySerialnumberMrbHandler : IRequestHandler<DeleteBySerialnumberCommonCommand<ToMrbDto>, bool>
{
    private readonly IToMrbRepository _repository;

    public DeleteBySerialnumberMrbHandler(IToMrbRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> Handle(DeleteBySerialnumberCommonCommand<ToMrbDto> request, CancellationToken cancellationToken)
    {
        var mrbEntity = await   _repository.GetBySerialNumberAsync(request.SerialNumber);
        if (mrbEntity == null)
            throw new EntityNotFoundException($"There is no failure associated with this serial number {request.SerialNumber}");
        
        //TODO: generate logs if the operation fail or if is succesfull.
        return await _repository.DeleteBySerialnumberAsync(request.SerialNumber);
    }
}
