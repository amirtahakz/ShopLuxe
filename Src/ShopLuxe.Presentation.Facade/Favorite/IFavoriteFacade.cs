using ShopLuxe.Application.Orders.AddItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopLuxe.Common.Application;
using ShopLuxe.Application.Favorite.Create;

namespace ShopLuxe.Presentation.Facade.Favorite
{
    public interface IFavoriteFacade
    {
        Task<OperationResult<Guid>> CreateFavorite(CreateFavoriteCommand command);
    }
}
