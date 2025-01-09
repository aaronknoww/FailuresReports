using MediatR;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Application.Mappers;
using Reports.Core.Common;

namespace Reports.Application.Handlers.Common.Commnad;

public class InsertRecordCommonCommandHandler<TEntity, TDto> : IRequestHandler<InsertRecordCommand<TDto>, bool>
    where TEntity : BaseEntity
    where TDto : BaseDto
{
    private readonly IGenericRepository<TEntity> _repository;

    public InsertRecordCommonCommandHandler(IGenericRepository<TEntity> repository)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public Task<bool> Handle(InsertRecordCommand<TDto> request, CancellationToken cancellationToken)
    {
        var entity = MapperLazyConf.Mapper.Map<TDto, TEntity>(request.EntityDto);

        return _repository.InsertRecordAsync(entity);
    }
}
