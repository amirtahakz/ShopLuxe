using ShopLuxe.Common.Query;
using ShopLuxe.Query.SiteEntities.DTOs;

namespace ShopLuxe.Query.SiteEntities.Sliders.GetById;

public record GetSliderByIdQuery(Guid SliderId) : IQuery<SliderDto>;
