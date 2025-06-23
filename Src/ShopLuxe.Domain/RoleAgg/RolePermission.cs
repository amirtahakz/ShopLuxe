using ShopLuxe.Common.Domain;
using ShopLuxe.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.RoleAgg
{
    public class RolePermission : BaseEntity
    {
        private RolePermission()
        {

        }
        public RolePermission(Permission permission)
        {
            Permission = permission;
        }
        public Guid RoleId { get; internal set; }
        public Permission Permission { get; private set; }
    }
}
