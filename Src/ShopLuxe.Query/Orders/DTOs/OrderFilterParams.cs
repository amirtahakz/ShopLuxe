using ShopLuxe.Common.Query.Filter;
using ShopLuxe.Domain.OrderAgg.Enums;

namespace ShopLuxe.Query.Orders.DTOs;

public class OrderFilterParams : BaseFilterParam
{
    public Guid? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public OrderStatus? Status { get; set; }

}