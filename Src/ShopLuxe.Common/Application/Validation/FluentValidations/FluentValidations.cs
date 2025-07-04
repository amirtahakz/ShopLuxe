﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using ShopLuxe.Common.Application.FileUtil;
using ShopLuxe.Common.Application.SecurityUtil;
using ShopLuxe.Common.Application.Validation;
using ShopLuxe.Common.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Common.Application.Validation.FluentValidations
{
    public static class FluentValidations
    {
        public static IRuleBuilderOptionsConditions<T, TProperty> JustImageFile<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string errorMessage = "شما فقط قادر به وارد کردن عکس میباشید") where TProperty : IFormFile?
        {
            return ruleBuilder.Custom((file, context) =>
            {
                if (file == null)
                    return;

                if (!file.IsImage())
                {
                    context.AddFailure(errorMessage);
                }
            });
        }

        public static IRuleBuilderOptionsConditions<T, string> ValidNationalId<T>(this IRuleBuilder<T, string> ruleBuilder, string errorMessage = "کدملی نامعتبر است")
        {
            return ruleBuilder.Custom((nationalCode, context) =>
            {
                if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                    context.AddFailure(errorMessage);
            });
        }
        public static IRuleBuilderOptionsConditions<T, string> ValidPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder, string errorMessage = ValidationMessages.InvalidPhoneNumber)
        {
            return ruleBuilder.Custom((phoneNumber, context) =>
            {
                if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length is < 11 or > 11)
                    context.AddFailure(errorMessage);

            });
        }

        public static IRuleBuilderOptionsConditions<T, TProperty> JustValidFile<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string errorMessage = "فایل نامعتبر است") where TProperty : IFormFile
        {
            return ruleBuilder.Custom((file, context) =>
            {
                if (file == null)
                    return;

                if (!file.IsValidFile())
                {
                    context.AddFailure(errorMessage);
                }
            });
        }
    }
}
