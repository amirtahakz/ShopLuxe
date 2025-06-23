using ShopLuxe.Common.Query;
using ShopLuxe.Query.Orders.DTOs;

namespace ShopLuxe.Query.Orders.GetByFilter;

public class GetOrderByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
{
    public GetOrderByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
    {
    }
}