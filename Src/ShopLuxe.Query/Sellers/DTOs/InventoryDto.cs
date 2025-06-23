using ShopLuxe.Common.Query;

namespace ShopLuxe.Query.Sellers.DTOs;

public class InventoryDto : BaseDto
{
    public Guid SellerId { get; set; }
    public string ShopName { get; set; }
    public Guid ProductId { get; set; }
    public string ProductTitle { get; set; }
    public string ProductImage { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public int DiscountPercentage { get; set; }
}