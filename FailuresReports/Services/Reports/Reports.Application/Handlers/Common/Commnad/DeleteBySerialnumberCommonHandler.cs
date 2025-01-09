using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Core.Common;

namespace Reports.Application.Handlers.Common.Commnad;

public class DeleteBySerialnumberCommonHandler<TEntity, TDto> : IRequestHandler<DeleteBySerialnumberCommonCommand<TDto>, bool>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    private readonly IGenericRepository<TEntity> _repository;

    public DeleteBySerialnumberCommonHandler(IGenericRepository<TEntity> repository)
    {
        this._repository = repository;
    }
    public async Task<bool> Handle(DeleteBySerialnumberCommonCommand<TDto> request, CancellationToken cancellationToken)
    {

        return await _repository.DeleteBySerialnumberAsync(request.SerialNumber);
    }
}
