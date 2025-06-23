using ShopLuxe.Common.Domain.ValueObjects;
using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Users.RegisterUser
{
    public class RegisterUserCommand : IBaseCommand
    {
        public RegisterUserCommand(string phoneNumber, string password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
    }
}
