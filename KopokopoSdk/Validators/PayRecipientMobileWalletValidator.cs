using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class PayRecipientMobileWalletValidator : AbstractValidator<PayRecipientMobileWalletRequest>
    {
        public PayRecipientMobileWalletValidator()
        {
            RuleFor(x => x.Type)
               .NotNull()
               .WithMessage("{PropertyName} - Type is required.")
               .NotEmpty()
               .WithMessage("{PropertyName} - Type should not be empty.");

            RuleFor(x => x.PayRecipient.FirstName)
                .NotNull()
                .WithMessage("{PropertyName} - First Name is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - First Name should not be empty.");

            RuleFor(x => x.PayRecipient.LastName)
                .NotNull()
                .WithMessage("{PropertyName} - Last Name is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Last Name should not be empty.");

            RuleFor(x => x.PayRecipient.PhoneNumber)
                .NotNull()
                .WithMessage("{PropertyName} - Phone number is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Phone number should not be empty.");

            RuleFor(x => x.PayRecipient.Network)
                .NotNull()
                .WithMessage("{PropertyName} - Network is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Network should not be empty.");
        }
    }
}
