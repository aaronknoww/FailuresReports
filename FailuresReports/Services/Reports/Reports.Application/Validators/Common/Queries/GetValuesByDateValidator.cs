using FluentValidation;
using Reports.Application.Querys.Common;

namespace Reports.Application.Validators.Common.Queries;

public class GetValuesByDateValidator<Dto> : AbstractValidator<GetValuesByDateQuery<Dto>> where Dto : class
{
    public GetValuesByDateValidator()
    {
        RuleFor(p=>p.maxRows)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Not negative values are allowd in {maxRows}")
            .LessThanOrEqualTo(200)
            .WithMessage("Not values greaters than 200 ara allowed in {maxRos}");
        RuleFor(p => p.Start)
            .NotEmpty()
            .WithMessage("{start} is required")
            .NotNull()
            .LessThanOrEqualTo(DateTime.Today)
            .WithMessage("Date must be today or in the past.")
            .LessThanOrEqualTo(x => x.End).WithMessage("Start date must be less than or equal to End date.");
        RuleFor(p => p.End)
            .NotEmpty()
            .WithMessage("{end} is required")
            .NotNull()
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("Date must be today or in the future.")
            .GreaterThanOrEqualTo(x => x.Start).WithMessage("End date must be greater than or equal to start date.");

        
    }

}
