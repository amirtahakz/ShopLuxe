using ShopLuxe.Domain.UserAgg;
using ShopLuxe.Domain.UserAgg.Repository;
using ShopLuxe.Infrastructure._Utilities;

namespace ShopLuxe.Infrastructure.Persistent.Ef.UserAgg
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}