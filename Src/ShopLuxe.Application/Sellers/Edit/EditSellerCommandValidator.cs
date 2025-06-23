using FluentValidation;
using ShopLuxe.Common.Application.Validation;
using ShopLuxe.Common.Application.Validation.FluentValidations;

namespace ShopLuxe.Application.Sellers.Edit
{
    public class EditSellerCommandValidator : AbstractValidator<EditSellerCommand>
    {
        public EditSellerCommandValidator()
        {
            RuleFor(r => r.ShopName)
                .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

            RuleFor(r => r.ShopName)
                .NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
                .ValidNationalId();
        }
    }

}
