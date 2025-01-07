using System;
using FluentValidation;
using Reports.Application.Querys.Common;

namespace Reports.Application.Validators.Common;

public class GetFailureByTestStationSysValidator<Dto> : AbstractValidator<GetFailureByTestStationSysQuery<Dto>> where Dto : class
{
    public GetFailureByTestStationSysValidator()
    {
        RuleFor(p => p.testStation)
            .NotEmpty()
            .WithMessage("{testStation} is required.")
            .NotNull()
            .MaximumLength(20)
            .WithMessage("{testStation} must not exceed 20 characters.");
    }

}
