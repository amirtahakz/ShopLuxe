using ShopLuxe.Common.Query.Filter;

namespace ShopLuxe.Query.Products.DTOs;

public class ProductFilterParams : BaseFilterParam
{
    public string? Title { get; set; }
    public Guid? Id { get; set; }
    public string? Slug { get; set; }
}