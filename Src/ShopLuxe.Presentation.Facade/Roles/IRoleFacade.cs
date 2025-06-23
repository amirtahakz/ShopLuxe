using ShopLuxe.Application.Roles.Create;
using ShopLuxe.Application.Roles.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Roles.DTOs;
namespace ShopLuxe.Presentation.Facade.Roles;

public interface IRoleFacade
{
    Task<OperationResult> CreateRole(CreateRoleCommand command);
    Task<OperationResult> EditRole(EditRoleCommand command);

    Task<RoleDto?> GetRoleById(Guid roleId);
    Task<List<RoleDto>> GetRoles();
}