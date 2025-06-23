using ShopLuxe.Common.Application;
using ShopLuxe.Common.Query;
using ShopLuxe.Query.SiteEntities.DTOs;

namespace ShopLuxe.Query.SiteEntities.ShippingMethods.GetById;

public record GetShippingMethodByIdQuery(Guid Id) : IQuery<ShippingMethodDto?>;