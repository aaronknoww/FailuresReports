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
    private readonly ILogger _logger;

    public DeleteBySerialnumberCommonHandler(IGenericRepository<TEntity> repository, ILogger logger)
    {
        this._repository = repository;
        this._logger = logger;
    }
    public async Task<bool> Handle(DeleteBySerialnumberCommonCommand<TDto> request, CancellationToken cancellationToken)
    {

       if(await _repository.DeleteBySerialnumberAsync(request.SerialNumber))
        {
            _logger.LogInformation($"Successfully deleted the record for this Serial Number {request.SerialNumber}");
            return true;
        }
        else
        {
            _logger.LogError($"Some error has occurred with this Serial Number {request.SerialNumber}");
            return false;
        }
        

    }
}
