using ShopLuxe.Common.Query;
using ShopLuxe.Query.Sellers.DTOs;

namespace ShopLuxe.Query.Sellers.Inventories.GetList;

public record GetInventoriesQuery(Guid SellerId) : IQuery<List<InventoryDto>>;