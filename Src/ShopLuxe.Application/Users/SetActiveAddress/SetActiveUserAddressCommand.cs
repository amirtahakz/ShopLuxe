using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Users.SetActiveAddress
{
    public record SetActiveUserAddressCommand(Guid UserId, Guid AddressId) : IBaseCommand;
}
