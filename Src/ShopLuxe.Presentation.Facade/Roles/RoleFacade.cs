using MediatR;
using ShopLuxe.Query.Roles.GetById;
using ShopLuxe.Query.Roles.GetList;
using ShopLuxe.Application.Roles.Create;
using ShopLuxe.Application.Roles.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Roles.DTOs;

namespace ShopLuxe.Presentation.Facade.Roles;

internal class RoleFacade : IRoleFacade
{
    private readonly IMediator _mediator;

    public RoleFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> CreateRole(CreateRoleCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> EditRole(EditRoleCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<RoleDto?> GetRoleById(Guid roleId)
    {
        return await _mediator.Send(new GetRoleByIdQuery(roleId));
    }
    public async Task<List<RoleDto>> GetRoles()
    {
        return await _mediator.Send(new GetRoleListQuery());
    }
}