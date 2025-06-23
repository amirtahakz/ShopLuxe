using ShopLuxe.Domain.SiteEntities;
using ShopLuxe.Domain.SiteEntities.Repositories;
using ShopLuxe.Infrastructure._Utilities;

namespace ShopLuxe.Infrastructure.Persistent.Ef.SiteEntities.Repositories;

internal class ShippingMethodRepository : BaseRepository<ShippingMethod>, IShippingMethodRepository
{
    public ShippingMethodRepository(ApplicationDbContext context) : base(context)
    {
    }

    public void Delete(ShippingMethod slider)
    {
        Context.ShippingMethods.Remove(slider);
    }
}