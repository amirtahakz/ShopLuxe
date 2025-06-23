using ShopLuxe.Common.Query;
using ShopLuxe.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Query.Categories.GetList
{
    public record GetCategoryListQuery : IQuery<List<CategoryDto>>;
}
