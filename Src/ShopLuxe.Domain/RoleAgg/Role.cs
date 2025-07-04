﻿using ShopLuxe.Common.Domain;
using ShopLuxe.Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.RoleAgg
{
    public class Role : BaseAggregateRoot
    {
        private Role()
        {

        }
        public Role(string title, List<RolePermission> permissions)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            Title = title;
            Permissions = permissions;
        }

        public Role(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            Title = title;
            Permissions = new List<RolePermission>();
        }

        public string Title { get; private set; }
        public List<RolePermission> Permissions { get; private set; }

        public void Edit(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title , nameof(title));
            Title = title;
        }

        public void SetPermissions(List<RolePermission> permissions)
        {
            Permissions = permissions;
        }
    }
}
