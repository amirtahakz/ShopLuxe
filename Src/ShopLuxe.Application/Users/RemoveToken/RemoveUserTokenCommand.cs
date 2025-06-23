using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Users.RemoveToken
{
    public record RemoveUserTokenCommand(Guid UserId, Guid TokenId) : IBaseCommand<string>;
}
