using ShopLuxe.Domain.SiteEntities;
using ShopLuxe.Domain.SiteEntities.Repositories;
using ShopLuxe.Infrastructure._Utilities;
using ShopLuxe.Infrastructure.Persistent.Ef;

namespace ShopLuxe.Infrastructure.Persistent.Ef.SiteEntities.Repositories
{
    internal class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        public BannerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Delete(Banner banner)
        {
            Context.Banners.Remove(banner);
        }
    }
}