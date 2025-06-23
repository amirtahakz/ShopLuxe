using FluentValidation;

namespace ShopLuxe.Application.SiteEntities.ShippingMethod.Create
{
    public class CreateShippingMethodCommandValidator : AbstractValidator<CreateShippingMethodCommand>
    {
        public CreateShippingMethodCommandValidator()
        {
            RuleFor(f => f.Title)
                .NotNull().NotEmpty();
        }
    }
}
