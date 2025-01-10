using FluentValidation;
using Reports.Application.Commands;
using Reports.Application.Dtos;
using Reports.Core.Common;

namespace Reports.Application.Validators.Common.Commands;

public class UpdateCommonCommandValidator<TEntity, TDto> : AbstractValidator<UpdateCommonCommand<TDto>>
where TEntity : BaseEntity
where TDto : BaseDto
{
    public UpdateCommonCommandValidator(IValidator<TDto> dtoValidator)
    {
        RuleFor(obj => obj.EntityDto)
            .NotNull()
            .WithMessage("The FailuresDto collection cannot be null.")
            .SetValidator(dtoValidator)
            .WithMessage("The EntityDto is not valid.");
        
    }

}
