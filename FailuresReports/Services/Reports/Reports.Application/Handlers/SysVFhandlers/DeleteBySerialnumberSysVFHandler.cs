using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Core.Repositories;

namespace Reports.Application.Handlers.SysVFhandlers;

public class DeleteBySerialnumberSysVFHandler : IRequestHandler<DeleteBySerialnumberCommonCommand<FailureRegistrationSYSVFDto>, bool>
{
    private readonly ISYSVFFailureRepository _repository;

    public DeleteBySerialnumberSysVFHandler(ISYSVFFailureRepository repository)
    {
        this._repository = repository;
    }
    public async Task<bool> Handle(DeleteBySerialnumberCommonCommand<FailureRegistrationSYSVFDto> request, CancellationToken cancellationToken)
    {
        var sysVfEntity = await _repository.GetBySerialNumberAsync(request.SerialNumber);
        //TODO: IMPLEMENT CLASS 
        if (sysVfEntity == null)
            throw new NotImplementedException();
        return await _repository.DeleteBySerialnumberAsync(request.SerialNumber);
    }
}
