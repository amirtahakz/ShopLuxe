using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Users.ChangePassword
{
    public class ChangeUserPasswordCommand : IBaseCommand
    {
        //public ChangeUserPasswordCommand(Guid userId, string currentPassword, string password)
        //{
        //    UserId = userId;
        //    CurrentPassword = currentPassword;
        //    Password = password;
        //}

        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
    }
}
