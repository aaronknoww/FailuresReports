using System;
using FluentValidation;
using Reports.Application.Dtos;

namespace Reports.Application.Validators.DtoValidators;

public class FailureDtoGenericValidator : AbstractValidator<FailiureDtoGeneric>
{
    public FailureDtoGenericValidator()
    {
        RuleFor(p => p.UserId)
            .NotEmpty()
            .WithMessage("{userId} is required. ")
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Not negative values are allowed");
        RuleFor(p => p.UserName) //TODO: check how to check if the user exist
            .NotEmpty()
            .WithMessage("{UserName} is required. ")
            .NotNull();
        RuleFor(p => p.SerialNumber)
            .NotEmpty()
            .WithMessage("{SerialNumber} is required.")
            .NotNull()
            .MaximumLength(11)
            .WithMessage("{SerialNumber} must not exceed 11 characters.");
        RuleFor(p => p.BU)
            .NotEmpty()
            .WithMessage("{bu} is required.")
            .NotNull()
            .MaximumLength(20)
            .WithMessage("{bu} must not exceed 20 characters.");
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