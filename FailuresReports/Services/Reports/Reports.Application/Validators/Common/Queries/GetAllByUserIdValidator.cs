using System;
using FluentValidation;
using Reports.Application.Querys.Common;

namespace Reports.Application.Validators.Common;

public class GetAllByUserIdValidator<Dto> : AbstractValidator<GetAllByUserIdQuery<Dto>> where Dto : class
{
    public GetAllByUserIdValidator()
    {
        RuleFor(p => p.userId)
            .NotEmpty()
            .WithMessage("{userId} is required. ")
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Not negative values are allowed");
        RuleFor(p=>p.maxRows)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Not negative values are allowd in {maxRows}")
            .LessThanOrEqualTo(200)
            .WithMessage("Not values greaters than 200 ara allowed in {maxRos}");
        RuleFor(p => p.start)
            .NotEmpty()
            .WithMessage("{start} is required")
            .NotNull()
            .LessThanOrEqualTo(DateTime.Today)
            .WithMessage("Date must be today or in the past.")
            .LessThanOrEqualTo(x => x.end).WithMessage("Start date must be less than or equal to End date.");
        RuleFor(p => p.end)
            .NotEmpty()
            .WithMessage("{end} is required")
            .NotNull()
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("Date must be today or in the future.")
            .GreaterThanOrEqualTo(x => x.start).WithMessage("End date must be greater than or equal to start date.");

    }

}