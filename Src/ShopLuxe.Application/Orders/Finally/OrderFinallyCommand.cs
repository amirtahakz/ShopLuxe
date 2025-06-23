using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Orders.Finally
{
    public record OrderFinallyCommand(Guid OrderId) : IBaseCommand;
}
