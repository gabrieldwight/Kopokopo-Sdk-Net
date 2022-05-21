using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class CreateTargetedTransferValidator : AbstractValidator<CreateTargetedTransferRequest>
    {
        public CreateTargetedTransferValidator()
        {
            RuleFor(x => x.Amount)
               .NotNull()
               .WithMessage("{PropertyName} - Amount is required.")
               .NotEmpty()
               .WithMessage("{PropertyName} - Amount should not be empty.");

            RuleFor(x => x.DestinationType)
                .NotNull()
                .WithMessage("{PropertyName} - Destination Type is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Destination Type should not be empty.");

            RuleFor(x => x.DestinationReference)
                .NotNull()
                .WithMessage("{PropertyName} - Destination Reference is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Destination Reference should not be empty.");

            RuleFor(x => x.Links)
                .NotNull()
                .WithMessage("{PropertyName} - Links is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Links should not be empty.");
        }
    }
}
