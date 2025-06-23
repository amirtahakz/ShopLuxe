using ShopLuxe.Common.Query;
using ShopLuxe.Query.Sellers.DTOs;

namespace ShopLuxe.Query.Sellers.Inventories.GetById;

public record GetSellerInventoryByIdQuery(Guid InventoryId) : IQuery<InventoryDto>;