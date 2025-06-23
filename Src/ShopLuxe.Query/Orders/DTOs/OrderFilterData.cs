﻿using ShopLuxe.Common.Query;
using ShopLuxe.Domain.OrderAgg.Enums;

namespace ShopLuxe.Query.Orders.DTOs;

public class OrderFilterData : BaseDto
{
    public Guid UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get; set; }
    public string? Shire { get; set; }
    public string? City { get; set; }
    public string? ShippingType { get; set; }
    public int TotalPrice { get; set; }
    public int TotalItemCount { get; set; }
}