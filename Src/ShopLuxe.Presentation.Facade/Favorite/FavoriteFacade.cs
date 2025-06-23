using MediatR;
using ShopLuxe.Application.Favorite.Create;
using ShopLuxe.Common.Application;

namespace ShopLuxe.Presentation.Facade.Favorite;

public class FavoriteFacade : IFavoriteFacade
{
    private readonly IMediator _mediator;

    public FavoriteFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult<Guid>> CreateFavorite(CreateFavoriteCommand command)
    {
        return await _mediator.Send(command);
    }
}