using ShopLuxe.Common.Query;
using ShopLuxe.Query.Users.DTOs;

namespace ShopLuxe.Query.Users.GetByFilter;

public class GetUserByFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
{
    public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
    {
    }
}