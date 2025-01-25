using FluentValidation;
using Reports.Application.Commands.CommonComan;
using Reports.Application.Dtos;

namespace Reports.Application.Validators;

public class DeleteBySerialnumberCommonValidator<Dto> : AbstractValidator<DeleteBySerialnumberCommonCommand<Dto>> where Dto : BaseDto
{
    public DeleteBySerialnumberCommonValidator()
    {
        RuleFor(p => p.SerialNumber)
            .NotEmpty()
            .WithMessage("{SerialNumber} is required.")
            .NotNull()
            .MaximumLength(11)
            .WithMessage("{SerialNumber} must not exceed 11 characters.");
    }

}
