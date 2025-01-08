using FluentValidation;
using Reports.Application.Dtos;

namespace Reports.Application.Validators.DtoValidators;

public class FailureRegistrationSYSVFDtoValidator : AbstractValidator<FailureRegistrationSYSVFDto>
{
    public FailureRegistrationSYSVFDtoValidator()
    {
        RuleFor(p=> p.Master)
            .NotNull()
            .MaximumLength(20)
            .WithMessage("{Master} must not exceed 20 characters.");
        RuleFor(p => p.Slot)
            .NotNull()
            //.GreaterThanOrEqualTo(50)
            .WithMessage("The value must be less or equal to 50");
        RuleFor(p => p.SubSlot)
            .NotNull()
            //.GreaterThanOrEqualTo(5)
            .WithMessage("The value must be less or equal to 50");

    }

}
