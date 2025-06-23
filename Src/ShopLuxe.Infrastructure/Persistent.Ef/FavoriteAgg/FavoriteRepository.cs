using ShopLuxe.Domain.FavoriteAgg;
using ShopLuxe.Domain.FavoriteAgg.Repository;
using ShopLuxe.Infrastructure._Utilities;

namespace ShopLuxe.Infrastructure.Persistent.Ef.FavoriteAgg
{
    public class FavoriteRepository : BaseRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
