using FluentValidation;
using KopokopoSdk.Requests;

namespace KopokopoSdk.Validators
{
    public class MpesaPaymentValidator : AbstractValidator<MpesaPaymentRequest>
    {
        public MpesaPaymentValidator()
        {
            RuleFor(x => x.PaymentChannel)
               .NotNull()
               .WithMessage("{PropertyName} - Payment channel is required.")
               .NotEmpty()
               .WithMessage("{PropertyName} - Payment channel should not be empty.");

            RuleFor(x => x.TillNumber)
                .NotNull()
                .WithMessage("{PropertyName} - Till number is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Till number not be empty.");

            RuleFor(x => x.Subscriber)
                .NotNull()
                .WithMessage("{PropertyName} - Subscriber is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Subscriber should not be empty.");

            RuleFor(x => x.Amount)
                .NotNull()
                .WithMessage("{PropertyName} - Amount is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Amount should not be empty.");

            RuleFor(x => x.Links)
                .NotNull()
                .WithMessage("{PropertyName} - Link is required.")
                .NotEmpty()
                .WithMessage("{PropertyName} - Link should not be empty.");
        }
    }
}
