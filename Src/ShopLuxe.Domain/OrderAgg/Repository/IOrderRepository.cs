using ShopLuxe.Domain.CategoryAgg;
using ShopLuxe.Common.Domain.Repository;
using ShopLuxe.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.OrderAgg.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetCurrentUserOrder(Guid userId);
    }
}
