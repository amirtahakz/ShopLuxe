using ShopLuxe.Api.Infrastructure.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopLuxe.Application.Roles.Create;
using ShopLuxe.Application.Roles.Edit;
using ShopLuxe.Common.AspNetCore;
using ShopLuxe.Domain.RoleAgg.Enums;
using ShopLuxe.Presentation.Facade.Roles;
using ShopLuxe.Query.Roles.DTOs;

namespace ShopLuxe.Api.Controllers;


[PermissionChecker(Permission.Role_Management)]
public class RoleController : ApiController
{
    private readonly IRoleFacade _roleFacade;

    public RoleController(IRoleFacade roleFacade)
    {
        _roleFacade = roleFacade;
    }

    [HttpGet]
    public async Task<ApiResult<List<RoleDto>>> GetRoles()
    {
        var result = await _roleFacade.GetRoles();
        return QueryResult(result);
    }

    [HttpGet("{roleId}")]
    public async Task<ApiResult<RoleDto?>> GetRoleById(Guid roleId)
    {
        var result = await _roleFacade.GetRoleById(roleId);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> CreateRole(CreateRoleCommand command)
    {
        var result = await _roleFacade.CreateRole(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> EditRole(EditRoleCommand command)
    {
        var result = await _roleFacade.EditRole(command);
        return CommandResult(result);
    }
}