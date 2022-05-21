using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class PayRecipientPaybillValidator : AbstractValidator<PayRecipientPaybillRequest>
    {
        public PayRecipientPaybillValidator()
        {
            RuleFor(x => x.Type)
               .NotNull()
               .WithMessage("{PropertyName} - Type is required.")
               .NotEmpty()
               .WithMessage("{PropertyName} - Type should not be empty.");

            RuleFor(x => x.PayRecipient.PaybillName)
                .NotNull()
                .WithMessage("{PropertyName} - Paybill Name is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Paybill Name should not be empty.");

            RuleFor(x => x.PayRecipient.PaybillNumber)
                .NotNull()
                .WithMessage("{PropertyName} - Paybill number is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Paybill number should not be empty.");

            RuleFor(x => x.PayRecipient.PaybillAccountNumber)
                .NotNull()
                .WithMessage("{PropertyName} - Paybill Account number is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Paybill Account number should not be empty.");
        }
    }
}
