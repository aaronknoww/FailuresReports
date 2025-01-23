using FluentValidation;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;
using Reports.Core.Common;

namespace Reports.Application.Validators.Common.Commands;

public class InsertAllByFailiureCommonCommandValidator<TEntity, TDto> : AbstractValidator<InsertAllByFailiureCommonCommand<TDto>>
where TEntity : FailureRegistrationGeneric
where TDto : FailiureDtoGeneric
{
    public InsertAllByFailiureCommonCommandValidator(IValidator<TDto> dtoValidator)
    {
        RuleFor(obj => obj.FailuresDto)
            .NotEmpty()
            .WithMessage("The FailuresDto collection cannot be empty.")
            .NotNull()
            .WithMessage("The FailuresDto collection cannot be null.");

        // Validate each item in the collection.
        RuleForEach(obj => obj.FailuresDto)
            .SetValidator(dtoValidator);
    }

}
