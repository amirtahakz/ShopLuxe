using ShopLuxe.Common.Query;
using ShopLuxe.Query.Products.DTOs;

namespace ShopLuxe.Query.Products.GetBySlug;

public record GetProductBySlugQuery(string Slug) : IQuery<ProductDto?>;