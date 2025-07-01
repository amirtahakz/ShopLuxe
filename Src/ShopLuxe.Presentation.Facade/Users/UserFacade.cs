using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using ShopLuxe.Query.Users.GetByFilter;
using ShopLuxe.Query.Users.GetById;
using ShopLuxe.Query.Users.GetByPhoneNumber;
using ShopLuxe.Query.Users.UserTokens;
using ShopLuxe.Query.Users.UserTokens.GetByJwtToken;
using ShopLuxe.Query.Users.UserTokens.GetByRefreshToken;
using ShopLuxe.Presentation.Facade;
using ShopLuxe.Common.Application.SecurityUtil;
using ShopLuxe.Common.CachHelper;
using ShopLuxe.Common.Application;
using ShopLuxe.Application.Users.Edit;
using ShopLuxe.Application.Users.RemoveToken;
using ShopLuxe.Application.Users.Create;
using ShopLuxe.Application.Users.RegisterUser;
using ShopLuxe.Application.Users.AddToken;
using ShopLuxe.Application.Users.ChangePassword;
using ShopLuxe.Query.Users.DTOs;
using ShopLuxe.Application.Users.EditRole;

namespace ShopLuxe.Presentation.Facade.Users;

internal class UserFacade : IUserFacade
{
    private readonly IMediator _mediator;
    private IDistributedCache _cache;
    public UserFacade(IMediator mediator, IDistributedCache cache)
    {
        _mediator = mediator;
        _cache = cache;
    }


    public async Task<OperationResult> CreateUser(CreateUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AddToken(AddUserTokenCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RemoveToken(RemoveUserTokenCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.Status != OperationResultStatus.Success)
            return OperationResult.Error();

        await _cache.RemoveAsync(CacheKeys.UserToken(result.Data));
        return OperationResult.Success();
    }

    public async Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command)
    {
        await _cache.RemoveAsync(CacheKeys.User(command.UserId));
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditUser(EditUserCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status == OperationResultStatus.Success)
            await _cache.RemoveAsync(CacheKeys.User(command.UserId));
        return result;
    }

    public async Task<OperationResult> EditUserRole(EditUserRoleCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.Status == OperationResultStatus.Success)
            await _cache.RemoveAsync(CacheKeys.User(command.UserId));
        return result;
    }

    public async Task<UserDto?> GetUserById(Guid userId)
    {
        return await _cache.GetOrSet(CacheKeys.User(userId), () =>
        {
            return _mediator.Send(new GetUserByIdQuery(userId));
        });
        //return await _mediator.Send(new GetUserByIdQuery(userId));
    }

    public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
    {
        var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
        return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));
    }

    public async Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken)
    {
        var hashJwtToken = Sha256Hasher.Hash(jwtToken);
        return await _cache.GetOrSet(CacheKeys.UserToken(hashJwtToken), () =>
        {
            return _mediator.Send(new GetUserTokenByJwtTokenQuery(hashJwtToken));
        });
    }

    public async Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
    {
        return await _mediator.Send(new GetUserByFilterQuery(filterParams));
    }

    public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
    {
        return await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
    }

    public async Task<OperationResult> RegisterUser(RegisterUserCommand command)
    {
        return await _mediator.Send(command);
    }
}