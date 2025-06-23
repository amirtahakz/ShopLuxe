using ShopLuxe.Common.Query;
using ShopLuxe.Query.Categories.DTOs;

namespace ShopLuxe.Query.Categories.GetByParentId;

public record GetCategoryByParentIdQuery(Guid ParentId) : IQuery<List<ChildCategoryDto>>;