using FluentValidation;
using Reports.Application.Dtos;

namespace Reports.Application.Validators.DtoValidators;

public class FailureRegistrationSYSFTDtoValidator : FailureDtoGenericValidator<FailureRegistrationSYSFTDto>
{
    public FailureRegistrationSYSFTDtoValidator()
    {
        RuleFor(p => p.TestCell)
            .NotNull()
            .MaximumLength(20)
            .WithMessage("{TestCell} must not exceed 20 characters.");
    }

}
