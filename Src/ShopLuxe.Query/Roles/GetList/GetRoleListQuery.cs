using ShopLuxe.Common.Query;
using ShopLuxe.Query.Roles.DTOs;

namespace ShopLuxe.Query.Roles.GetList;

public record GetRoleListQuery : IQuery<List<RoleDto>>;