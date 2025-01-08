using System;
using FluentValidation;
using Reports.Application.Querys.Common;

namespace Reports.Application.Validators.Common;
public class GetFailureByAreaSysValidator<Dto> : AbstractValidator<GetAllFailureByAreaSysQuery<Dto>> where Dto : class
{
    public GetFailureByAreaSysValidator()
    {
        RuleFor(p => p.testArea)
            .NotEmpty()
            .WithMessage("{testArea} is required.")
            .NotNull()
            .MaximumLength(20)
            .WithMessage("{testArea} must not exceed 20 characters.");
        
    }

}
