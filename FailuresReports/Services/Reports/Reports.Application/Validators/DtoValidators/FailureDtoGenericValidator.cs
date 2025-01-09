using FluentValidation;
using Reports.Application.Dtos;

namespace Reports.Application.Validators.DtoValidators;

public class FailureDtoGenericValidator<TDto> : BaseDtoValidator<TDto> where TDto : FailiureDtoGeneric
{
    public FailureDtoGenericValidator()
    {
        
        RuleFor(p => p.TestArea)
            .NotEmpty()
            .WithMessage("{testArea} is required.")
            .NotNull()
            .MaximumLength(20)
            .WithMessage("{testArea} must not exceed 20 characters.");
        RuleFor(p => p.TestStation)
            .NotEmpty()
            .WithMessage("{testStation} is required.")
            .NotNull()
            .MaximumLength(20)
            .WithMessage("{testStation} must not exceed 20 characters.");
        RuleFor(p => p.Failure)
            .NotEmpty()
            .WithMessage("{Failiure} is required.")
            .NotNull()
            .MaximumLength(20)
            .WithMessage("{Failiure} must not exceed 20 characters.");
        RuleFor(p => p.Cause)
            .NotEmpty()
            .WithMessage("{Cause} is required.")
            .NotNull()
            .MaximumLength(200)
            .WithMessage("{Cause} must not exceed 200 characters.");
        RuleFor(p => p.Solution)
            .NotEmpty()
            .WithMessage("{Solution} is required.")
            .NotNull()
            .MaximumLength(200)
            .WithMessage("{Solution} must not exceed 200 characters.");
        RuleFor(p => p.RegistrationDate)
            .NotEmpty()
            .WithMessage("{RegistrationDate} is required")
            .NotNull()
            .LessThanOrEqualTo(DateTime.Today)
            .WithMessage("Date must be today or in the past.");

    }

}