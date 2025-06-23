using ShopLuxe.Common.Query;

namespace ShopLuxe.Query.SiteEntities.DTOs;

public class ShippingMethodDto : BaseDto
{
    public string Title { get; set; }
    public int Cost { get; set; }
}