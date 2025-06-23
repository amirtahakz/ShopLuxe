using Microsoft.AspNetCore.Http;
using ShopLuxe.Common.Application;
using ShopLuxe.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Users.Edit
{
    public class EditUserCommand : IBaseCommand
    {
        //public EditUserCommand(Guid userId, IFormFile? avatar, string name, string family, string phoneNumber, string email, Gender gender)
        //{
        //    UserId = userId;
        //    Avatar = avatar;
        //    Name = name;
        //    Family = family;
        //    PhoneNumber = phoneNumber;
        //    Email = email;
        //    Gender = gender;
        //}
        public Guid UserId { get; set; }
        public IFormFile? Avatar { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
}
