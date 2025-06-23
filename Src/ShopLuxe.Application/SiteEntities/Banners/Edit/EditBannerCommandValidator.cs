using FluentValidation;
using ShopLuxe.Common.Application.Validation;
using ShopLuxe.Common.Application.Validation.FluentValidations;

namespace ShopLuxe.Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommandValidator : AbstractValidator<EditBannerCommand>
    {
        public EditBannerCommandValidator()
        {
            RuleFor(r => r.ImageFile)
                .JustImageFile();

            RuleFor(r => r.Link)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("لینک"));
        }
    }
}
