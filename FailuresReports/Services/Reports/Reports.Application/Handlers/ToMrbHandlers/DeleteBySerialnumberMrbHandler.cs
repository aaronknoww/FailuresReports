using System;
using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
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
        //TODO: create a class exeption.
        if (mrbEntity == null)
            throw new ArgumentException("");
        return await _repository.DeleteBySerialnumberAsync(request.SerialNumber);
    }
}
