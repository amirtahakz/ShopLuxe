using ShopLuxe.Common.Application;
using ShopLuxe.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Roles.Edit
{
    public record EditRoleCommand(Guid Id, string Title, List<Permission> Permissions) : IBaseCommand;
}
