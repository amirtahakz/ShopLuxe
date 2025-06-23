using ShopLuxe.Common.Query;

namespace ShopLuxe.Query.Products.DTOs;

public class ProductSpecificationDto : BaseDto
{
    public string Key { get; set; }
    public string Value { get; set; }
}