﻿using FluentValidation;
using ShopLuxe.Common.Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Categories.Edit
{
    public class EditCategoryCommandValidator: AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(r => r.Slug)
              .NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
        }
    }
}
