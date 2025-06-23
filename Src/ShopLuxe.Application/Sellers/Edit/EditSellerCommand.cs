using ShopLuxe.Common.Application;
using ShopLuxe.Domain.SellerAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Sellers.Edit
{
    public record EditSellerCommand(Guid Id, string ShopName, string NationalCode, SellerStatus Status) : IBaseCommand;

}
