using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Orders.RemoveItem
{
    public record RemoveOrderItemCommand(Guid UserId, Guid ItemId) : IBaseCommand;
}
