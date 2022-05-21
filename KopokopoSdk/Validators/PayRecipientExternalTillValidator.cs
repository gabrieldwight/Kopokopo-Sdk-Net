using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class PayRecipientExternalTillValidator : AbstractValidator<PayRecipientExternalTillRequest>
    {
        public PayRecipientExternalTillValidator()
        {
            RuleFor(x => x.Type)
               .NotNull()
               .WithMessage("{PropertyName} - Type is required.")
               .NotEmpty()
               .WithMessage("{PropertyName} - Type should not be empty.");

            RuleFor(x => x.PayRecipient.TillName)
                .NotNull()
                .WithMessage("{PropertyName} - Till Name is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Till Name should not be empty.");

            RuleFor(x => x.PayRecipient.TillNumber)
                .NotNull()
                .WithMessage("{PropertyName} - Till Number is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Till Number should not be empty.");
        }
    }
}
