using FluentValidation;
using ShopLuxe.Common.Application.Validation;

namespace ShopLuxe.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommandValidator : AbstractValidator<ChargeUserWalletCommand>
    {
        public ChargeUserWalletCommandValidator()
        {
            RuleFor(r => r.Description)
                .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

            RuleFor(r => r.Price)
                .GreaterThanOrEqualTo(1000);
        }
    }
}
