using ShopLuxe.Common.Query;
using ShopLuxe.Domain.OrderAgg;
using ShopLuxe.Domain.OrderAgg.Enums;
using ShopLuxe.Domain.OrderAgg.ValueObjects;

namespace ShopLuxe.Query.Orders.DTOs;

public class OrderDto : BaseDto
{
    public Guid UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get; set; }
    public OrderDiscount? Discount { get; set; }
    public OrderAddress? Address { get; set; }
    public OrderShippingMethod? ShippingMethod { get; set; }
    public List<OrderItemDto> Items { get; set; }
    public DateTime? LastUpdate { get; set; }


    public int TotalPrice
    {
        get
        {
            var total = Items.Sum(s => s.TotalPrice);
            if (Discount != null)
            {
                total -= Discount.DiscountAmount;
            }
            total += ShippingMethod?.ShippingCost ?? 0;
            return total;
        }
    }
}