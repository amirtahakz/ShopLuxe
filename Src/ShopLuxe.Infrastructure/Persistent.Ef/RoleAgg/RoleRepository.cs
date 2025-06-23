
using ShopLuxe.Domain.RoleAgg;
using ShopLuxe.Domain.RoleAgg.Repository;
using ShopLuxe.Infrastructure._Utilities;
using ShopLuxe.Infrastructure.Persistent.Ef;

namespace ShopLuxe.Infrastructure.Persistent.Ef.RoleAgg;

internal class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}