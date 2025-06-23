using System.ComponentModel.DataAnnotations;
using ShopLuxe.Common.Application.Validation.CustomValidation.IFormFile;
using ShopLuxe.Domain.UserAgg.Enums;

namespace ShopLuxe.Api.ViewModels.Users;

public class EditUserViewModel
{
    [Display(Name = "عکس پروفایل")]
    [FileImage(ErrorMessage = "تصویر پروفایل نامعتبر است")]
    public IFormFile? Avatar { get; set; }

    [Display(Name = "نام")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Name { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Family { get; set; }

    [Display(Name = "شماره تلفن")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string PhoneNumber { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Email { get; set; }

    public Gender Gender { get; set; } = Gender.None;
}