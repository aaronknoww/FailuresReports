using FluentValidation;
using Reports.Application.Querys.Common;

namespace Reports.Application.Validators.Common;

public class GetFailureByBuSysValidator<Dto> : AbstractValidator<GetFailureByBuSysQuery<Dto>> where Dto : class
{

    public GetFailureByBuSysValidator()
    {
        RuleFor(p => p.bu)
            .NotEmpty()
            .WithMessage("{bu} is required.")
            .NotNull()
            .MaximumLength(20)
            .WithMessage("{bu} must not exceed 20 characters.");
    }

}
