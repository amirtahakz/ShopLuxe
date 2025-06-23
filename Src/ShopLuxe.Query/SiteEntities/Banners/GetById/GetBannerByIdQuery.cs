using ShopLuxe.Common.Query;
using ShopLuxe.Query.SiteEntities.DTOs;

namespace ShopLuxe.Query.SiteEntities.Banners.GetById;

public record GetBannerByIdQuery(Guid BannerId) : IQuery<BannerDto>;