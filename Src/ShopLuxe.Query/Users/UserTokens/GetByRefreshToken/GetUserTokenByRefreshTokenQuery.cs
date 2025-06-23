using ShopLuxe.Common.Query;
using ShopLuxe.Query.Users.DTOs;

namespace ShopLuxe.Query.Users.UserTokens.GetByRefreshToken;

public record GetUserTokenByRefreshTokenQuery(string HashRefreshToken) : IQuery<UserTokenDto?>;