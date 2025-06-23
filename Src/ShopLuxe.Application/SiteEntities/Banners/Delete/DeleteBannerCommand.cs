using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.SiteEntities.Banners.Delete
{
    public record DeleteBannerCommand(Guid Id) : IBaseCommand;
}
