using ShopLuxe.Domain.CategoryAgg;
using ShopLuxe.Common.Application;
using ShopLuxe.Domain.FavoriteAgg.Repository;

namespace ShopLuxe.Application.Favorite.Create;

public class CreateFavoriteCommandHandler : IBaseCommandHandler<CreateFavoriteCommand , Guid>
{
    private readonly IFavoriteRepository _favoriteRepository;

    public CreateFavoriteCommandHandler(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }
    public async Task<OperationResult<Guid>> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
    {
        var entityModel = new Domain.FavoriteAgg.Favorite(request.UserId , request.ProductId);
        await _favoriteRepository.AddAsync(entityModel);
        await _favoriteRepository.Save();

        return OperationResult<Guid>.Success(entityModel.Id);
    }
}