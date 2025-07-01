using ShopLuxe.Application.Roles.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Domain.RoleAgg;
using ShopLuxe.Domain.RoleAgg.Repository;
using ShopLuxe.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Users.EditRole
{
    public record EditUserRoleCommand(Guid UserId , List<UserRole> Roles) : IBaseCommand;
}
