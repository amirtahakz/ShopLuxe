using ShopLuxe.Common.Domain.Utils;
using ShopLuxe.Domain.CategoryAgg;
using ShopLuxe.Domain.CategoryAgg.Services;
using ShopLuxe.Common.Application;
using ShopLuxe.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Categories.Create
{
    public record CreateCategoryCommand(string Slug, string Title, SeoData SeoData) : IBaseCommand<Guid>;
}
