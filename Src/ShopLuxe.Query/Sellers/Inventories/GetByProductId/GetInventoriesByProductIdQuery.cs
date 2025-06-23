using ShopLuxe.Common.Query;
using ShopLuxe.Query.Sellers.DTOs;

namespace ShopLuxe.Query.Sellers.Inventories.GetByProductId;

public record GetInventoriesByProductIdQuery(Guid ProductId) : IQuery<List<InventoryDto>>;