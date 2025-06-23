using ShopLuxe.Domain.SiteEntities;
using ShopLuxe.Domain.SiteEntities.Repositories;
using ShopLuxe.Infrastructure._Utilities;
using ShopLuxe.Infrastructure.Persistent.Ef;

namespace ShopLuxe.Infrastructure.Persistent.Ef.SiteEntities.Repositories;

internal class SliderRepository : BaseRepository<Slider>, ISliderRepository
{
    public SliderRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void Delete(Slider slider)
    {
        Context.Sliders.Remove(slider);
    }
}