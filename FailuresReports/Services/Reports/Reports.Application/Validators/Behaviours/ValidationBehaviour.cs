using FluentValidation;
using MediatR;

namespace Reports.Application.Validators.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);
            //This will run all the validation rules one by one and returns the validation result
                FluentValidation.Results.ValidationResult[] validationResults = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                //now need to check for any failure
                var failures = validationResults.SelectMany(e => e.Errors).Where(f => f != null).ToList();
                if(failures.Count!=0)
                {
                    throw new ValidationException(failures);
                }
            }
            //On success case 
            return await next();
        }
}