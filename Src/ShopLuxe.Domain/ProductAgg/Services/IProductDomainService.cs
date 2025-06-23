using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.ProductAgg.Services
{
    public interface IProductDomainService
    {
        bool SlugIsExist(string slug);
    }
}
