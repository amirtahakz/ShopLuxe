using ShopLuxe.Common.Query;
using ShopLuxe.Domain.SiteEntities.Enums;

namespace ShopLuxe.Query.SiteEntities.DTOs;

public class BannerDto : BaseDto
{
    public string Link { get; set; }
    public string ImageName { get; set; }
    public BannerPosition Position { get; set; }
}
