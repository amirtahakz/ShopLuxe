using ShopLuxe.Application.Orders.AddItem;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopLuxe.Presentation.Facade.Orders;
using ShopLuxe.Application.Favorite.Create;
using ShopLuxe.Common.AspNetCore;
using ShopLuxe.Presentation.Facade.Favorite;

namespace ShopLuxe.Api.Controllers
{
    public class FavoriteController : ApiController
    {
        private readonly IFavoriteFacade _favoriteFacade;

        public FavoriteController(IFavoriteFacade favoriteFacade)
        {
            _favoriteFacade = favoriteFacade;
        }


        [HttpPost]
        public async Task<ApiResult<Guid>> CreateFavorite(CreateFavoriteCommand command)
        {
            var result = await _favoriteFacade.CreateFavorite(command);
            return CommandResult(result);
        }
    }
}
