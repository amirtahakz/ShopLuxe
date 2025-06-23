using FluentValidation;
using ShopLuxe.Common.Application.Validation;
using ShopLuxe.Common.Application.Validation.FluentValidations;

namespace ShopLuxe.Application.SiteEntities.Sliders.Create
{
    public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {
            RuleFor(r => r.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();

            RuleFor(r => r.Link)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("لینک"));

            RuleFor(r => r.Title)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }
}
