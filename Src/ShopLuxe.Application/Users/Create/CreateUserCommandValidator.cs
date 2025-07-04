﻿using FluentValidation;
using ShopLuxe.Common.Application.Validation;
using ShopLuxe.Common.Application.Validation.FluentValidations;

namespace ShopLuxe.Application.Users.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(r => r.PhoneNumber)
                .ValidPhoneNumber();

            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("ایمیل نامعتبر است");

            RuleFor(f => f.Password)
                .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
                .NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
                .MinimumLength(4).WithMessage("کلمه عبور باید بشتر از 4 کارکتر باشد");
        }
    }
}
