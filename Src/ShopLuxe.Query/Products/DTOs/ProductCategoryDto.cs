using ShopLuxe.Common.Domain.ValueObjects;
using ShopLuxe.Common.Query;

namespace ShopLuxe.Query.Products.DTOs;

public class ProductCategoryDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
}