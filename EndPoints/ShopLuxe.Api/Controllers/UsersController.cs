using ShopLuxe.Api.Infrastructure.Security;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopLuxe.Api.ViewModels.Users;
using ShopLuxe.Application.Users.ChangePassword;
using ShopLuxe.Application.Users.Create;
using ShopLuxe.Application.Users.Edit;
using ShopLuxe.Common.AspNetCore;
using ShopLuxe.Domain.RoleAgg.Enums;
using ShopLuxe.Presentation.Facade.Users;
using ShopLuxe.Query.Users.DTOs;
using ShopLuxe.Application.Users.EditRole;

namespace ShopLuxe.Api.Controllers;


[Authorize]
public class UsersController : ApiController
{
    private readonly IUserFacade _userFacade;
    private readonly IMapper _mapper;
    public UsersController(IUserFacade userFacade, IMapper mapper)
    {
        _userFacade = userFacade;
        _mapper = mapper;
    }
    [PermissionChecker(Permission.User_Management)]
    [HttpGet]
    public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery] UserFilterParams filterParams)
    {
        var result = await _userFacade.GetUserByFilter(filterParams);
        return QueryResult(result);
    }
    [HttpGet("Current")]
    public async Task<ApiResult<UserDto>> GetCurrentUser()
    {
        var result = await _userFacade.GetUserById(User.GetUserId());
        return QueryResult(result);
    }

    [PermissionChecker(Permission.User_Management)]
    [HttpGet("{userId}")]
    public async Task<ApiResult<UserDto?>> GetById(Guid userId)
    {
        var result = await _userFacade.GetUserById(userId);
        return QueryResult(result);
    }

    [PermissionChecker(Permission.User_Management)]
    [HttpPost]
    public async Task<ApiResult> Create(CreateUserCommand command)
    {
        var result = await _userFacade.CreateUser(command);
        return CommandResult(result);
    }

    [HttpPut("ChangePassword")]
    public async Task<ApiResult> ChangePassword(ChangePasswordViewModel command)
    {
        var changePasswordModel = _mapper.Map<ChangeUserPasswordCommand>(command);
        changePasswordModel.UserId = User.GetUserId();
        var result = await _userFacade.ChangePassword(changePasswordModel);
        return CommandResult(result);
    }

    [HttpPut("Current")]
    public async Task<ApiResult> EditUser([FromForm] EditUserViewModel command)
    {
        var commandModel = new EditUserCommand()
        {
            UserId = User.GetUserId(),
            Avatar = command.Avatar,
            Email = command.Email,
            Family = command.Family,
            Gender = command.Gender,
            Name = command.Name,
            PhoneNumber = command.PhoneNumber,
        };

        var result = await _userFacade.EditUser(commandModel);
        return CommandResult(result);
    }

    [PermissionChecker(Permission.User_Management)]
    [HttpPut]
    public async Task<ApiResult> Edit([FromForm] EditUserCommand command)
    {
        var result = await _userFacade.EditUser(command);
        return CommandResult(result);
    }

    [PermissionChecker(Permission.Role_Management)]
    [PermissionChecker(Permission.PanelAdmin)]
    [HttpPut("EditUserRole")]
    public async Task<ApiResult> EditUserRole([FromBody] EditUserRoleCommand command)
    {
        var result = await _userFacade.EditUserRole(command);
        return CommandResult(result);
    }
}