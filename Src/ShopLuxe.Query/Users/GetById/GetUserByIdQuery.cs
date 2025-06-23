using ShopLuxe.Common.Query;
using ShopLuxe.Query.Users.DTOs;

namespace ShopLuxe.Query.Users.GetById;

public class GetUserByIdQuery : IQuery<UserDto?>
{
    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; private set; }
}