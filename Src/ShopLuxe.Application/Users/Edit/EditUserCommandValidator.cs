using FluentValidation;
using ShopLuxe.Common.Application.Validation.FluentValidations;

namespace ShopLuxe.Application.Users.Edit
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(r => r.PhoneNumber)
                .ValidPhoneNumber();

            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("ایمیل نامعتبر است");


            RuleFor(f => f.Avatar)
                .JustImageFile();
        }
    }
}
