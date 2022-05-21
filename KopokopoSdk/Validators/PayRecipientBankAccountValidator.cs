using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class PayRecipientBankAccountValidator : AbstractValidator<PayRecipientBankAccountRequest>
    {
        public PayRecipientBankAccountValidator()
        {
            RuleFor(x => x.Type)
               .NotNull()
               .WithMessage("{PropertyName} - Type is required.")
               .NotEmpty()
               .WithMessage("{PropertyName} - Type should not be empty.");

            RuleFor(x => x.PayRecipient.AccountName)
                .NotNull()
                .WithMessage("{PropertyName} - Account Name is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Account Name should not be empty.");

            RuleFor(x => x.PayRecipient.BankBranchRef)
                .NotNull()
                .WithMessage("{PropertyName} - Bank Branch Reference is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Bank Branch Reference should not be empty.");

            RuleFor(x => x.PayRecipient.AccountNumber)
                .NotNull()
                .WithMessage("{PropertyName} - Account number is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Account number should not be empty.");

            RuleFor(x => x.PayRecipient.SettlementMethod)
                .NotNull()
                .WithMessage("{PropertyName} - Settlement method is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Settlement method should not be empty.");
        }
    }
}
