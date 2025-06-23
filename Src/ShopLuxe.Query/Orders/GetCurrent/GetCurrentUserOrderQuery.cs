using ShopLuxe.Common.Query;
using ShopLuxe.Query.Orders.DTOs;

namespace ShopLuxe.Query.Orders.GetCurrent;

public record GetCurrentUserOrderQuery(Guid UserId) : IQuery<OrderDto?>;