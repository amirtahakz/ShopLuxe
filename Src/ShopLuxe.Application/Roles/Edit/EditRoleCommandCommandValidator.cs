using FluentValidation;
using ShopLuxe.Common.Application.Validation;

namespace ShopLuxe.Application.Roles.Edit
{
    public class EditRoleCommandCommandValidator : AbstractValidator<EditRoleCommand>
    {
        public EditRoleCommandCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }

}
