using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class CreateMerchantBankAccountValidator : AbstractValidator<CreateMerchantBankAccountRequest>
    {
        public CreateMerchantBankAccountValidator()
        {
            RuleFor(x => x.AccountName)
               .NotNull()
               .WithMessage("{PropertyName} - Account name is required.")
               .NotEmpty()
               .WithMessage("{PropertyName} - Account name should not be empty.");

            RuleFor(x => x.BankBranchRef)
                .NotNull()
                .WithMessage("{PropertyName} - Bank Branch Reference is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Bank Branch Reference should not be empty.");

            RuleFor(x => x.AccountNumber)
                .NotNull()
                .WithMessage("{PropertyName} - Account number is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Amount number should not be empty.");

            RuleFor(x => x.SettlementMethod)
                .NotNull()
                .WithMessage("{PropertyName} - Settlement method is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Settlemnt method should not be empty.");
        }
    }
}
