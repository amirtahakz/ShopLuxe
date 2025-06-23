using ShopLuxe.Common.Query;
using ShopLuxe.Query.Products.DTOs;

namespace ShopLuxe.Query.Products.GetById;

public record GetProductByIdQuery(Guid Id) : IQuery<ProductDto?>;