using ShopLuxe.Common.Query;
using ShopLuxe.Query.Sellers.DTOs;

namespace ShopLuxe.Query.Sellers.GetByUserId;

public record GetSellerByUserIdQuery(Guid UserId) : IQuery<SellerDto?>;