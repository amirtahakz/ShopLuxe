using ShopLuxe.Application.Users.AddToken;
using ShopLuxe.Application.Users.ChangePassword;
using ShopLuxe.Application.Users.Create;
using ShopLuxe.Application.Users.Edit;
using ShopLuxe.Application.Users.EditRole;
using ShopLuxe.Application.Users.RegisterUser;
using ShopLuxe.Application.Users.RemoveToken;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Users.DTOs;

namespace ShopLuxe.Presentation.Facade.Users
{
    public interface IUserFacade
    {
        Task<OperationResult> RegisterUser(RegisterUserCommand command);
        Task<OperationResult> EditUser(EditUserCommand command);
        Task<OperationResult> EditUserRole(EditUserRoleCommand command);
        Task<OperationResult> CreateUser(CreateUserCommand command);
        Task<OperationResult> AddToken(AddUserTokenCommand command);
        Task<OperationResult> RemoveToken(RemoveUserTokenCommand command);
        Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command);

        Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
        Task<UserDto?> GetUserById(Guid userId);
        Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken);
        Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken);
        Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);
    }
}