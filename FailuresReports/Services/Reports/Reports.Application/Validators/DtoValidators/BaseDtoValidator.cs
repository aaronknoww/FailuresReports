using FluentValidation;
using Reports.Application.Dtos;

namespace Reports.Application.Validators.DtoValidators;

public class BaseDtoValidator<TDto> : AbstractValidator<TDto> where TDto : BaseDto
{
    public BaseDtoValidator()
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
        
    }

}
