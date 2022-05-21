using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class PollTransactionValidator : AbstractValidator<PollTransactionRequest>
    {
        public PollTransactionValidator()
        {
            RuleFor(x => x.Scope)
               .NotNull()
               .WithMessage("{PropertyName} - Scope is required.")
               .NotEmpty()
               .WithMessage("{PropertyName} - Scope should not be empty.");

            RuleFor(x => x.ScopeReference)
                .NotNull()
                .WithMessage("{PropertyName} - Scope Reference is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Scope Reference should not be empty.");

            RuleFor(x => x.FromTime)
                .NotNull()
                .WithMessage("{PropertyName} - From time is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - From time should not be empty.");

            RuleFor(x => x.ToTime)
                .NotNull()
                .WithMessage("{PropertyName} - To time is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - To time should not be empty.");

            RuleFor(x => x.Links)
                .NotNull()
                .WithMessage("{PropertyName} - Links is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Links should not be empty.");
        }
    }
}
