using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.SellerAgg.Services
{
    public interface ISellerDomainService
    {
        bool NationalCodeExistInDataBase(string nationalCode);
        bool IsValidSellerInformation(Seller seller);
    }
}
