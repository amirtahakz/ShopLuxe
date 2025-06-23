using ShopLuxe.Domain.CategoryAgg.Services;
using ShopLuxe.Common.Application;
using ShopLuxe.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Categories.AddChild
{
    public record AddChildCategoryCommand(Guid ParentId ,string Title, string Slug, SeoData SeoData) : IBaseCommand<Guid>;
}
