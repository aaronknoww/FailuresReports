using FluentValidation;
using Reports.Application.Querys.Common;

namespace Reports.Application.Validators.Common;

public class GetBySerialNumberValidator<Dto> : AbstractValidator<GetAllValuesBySerialNumberQuery<Dto>> where Dto : class
{
    public GetBySerialNumberValidator()
    {
        RuleFor(p => p.SerialNumber)
            .NotEmpty()
            .WithMessage("{SerialNumber} is required.")
            .NotNull()
            .MaximumLength(11)
            .WithMessage("{SerialNumber} must not exceed 11 characters.");
    }

}
