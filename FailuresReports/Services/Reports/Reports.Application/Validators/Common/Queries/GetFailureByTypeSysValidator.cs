using FluentValidation;
using Reports.Application.Querys.Common;

namespace Reports.Application.Validators.Common;

public class GetFailureByTypeSysValidator<Dto> : AbstractValidator<GetAllFailureByTypeSysQuery<Dto>> where Dto : class, IEntity
{
    public GetFailureByTypeSysValidator()
    {
        RuleFor(p => p.type)
            .NotEmpty()
            .WithMessage("{type} is required.")
            .NotNull()
            .MaximumLength(20)
            .WithMessage("{type} must not exceed 20 characters.");
        
    }

}
