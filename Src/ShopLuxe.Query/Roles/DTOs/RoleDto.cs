using ShopLuxe.Common.Query;
using ShopLuxe.Domain.RoleAgg.Enums;

namespace ShopLuxe.Query.Roles.DTOs;

public class RoleDto : BaseDto
{
    public string Title { get; set; }
    public List<Permission> Permissions { get; set; }
}