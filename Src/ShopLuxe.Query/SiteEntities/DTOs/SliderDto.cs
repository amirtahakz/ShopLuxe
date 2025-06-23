using ShopLuxe.Common.Query;

namespace ShopLuxe.Query.SiteEntities.DTOs;

public class SliderDto : BaseDto
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string ImageName { get; set; }
}