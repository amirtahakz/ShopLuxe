using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopLuxe.Application.Products.Create;
using ShopLuxe.Common.Application;

namespace ShopLuxe.Application.Favorite.Create
{
    public class CreateFavoriteCommand : IBaseCommand<Guid>
    {
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }
    }
}
