using FluentValidation;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Core.Common;

namespace Reports.Application.Validators.Common.Commands;

public class InsertRecordCommandCommonValidator<TEntity, TDto> : AbstractValidator<InsertRecordCommand<TDto>>
where TEntity : BaseEntity
where TDto : BaseDto
{
    public InsertRecordCommandCommonValidator(IValidator<TDto> dtoValidator)
    {        
        RuleFor(obj => obj.EntityDto)
            .NotNull()
            .WithMessage("The FailuresDto collection cannot be null.")
            .SetValidator(dtoValidator)
            .WithMessage("The EntityDto is not valid.");
        
    }

}
