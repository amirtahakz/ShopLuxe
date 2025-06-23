using Microsoft.EntityFrameworkCore;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Infrastructure._Utilities;
using ShopLuxe.Domain.OrderAgg;
using ShopLuxe.Domain.OrderAgg.Repository;
using ShopLuxe.Domain.OrderAgg.Enums;

namespace ShopLuxe.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository
    {

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Order?> GetCurrentUserOrder(Guid userId)
        {
            return await Context.Orders.AsTracking().FirstOrDefaultAsync(f => f.UserId == userId
            && f.Status == OrderStatus.Pending);
        }

       
    }
}