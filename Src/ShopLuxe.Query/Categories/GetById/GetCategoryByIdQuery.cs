using ShopLuxe.Common.Query;
using ShopLuxe.Query.Categories.DTOs;

namespace ShopLuxe.Query.Categories.GetById;

public record GetCategoryByIdQuery(Guid CategoryId) : IQuery<CategoryDto>;