using ShopLuxe.Common.Domain.Repository;
using ShopLuxe.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.SiteEntities.Repositories
{
    public interface IShippingMethodRepository : IBaseRepository<ShippingMethod>
    {
        void Delete(ShippingMethod method);
    }
}
