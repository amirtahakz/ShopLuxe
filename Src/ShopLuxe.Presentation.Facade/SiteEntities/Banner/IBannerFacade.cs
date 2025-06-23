using ShopLuxe.Application.SiteEntities.Banners.Create;
using ShopLuxe.Application.SiteEntities.Banners.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.SiteEntities.DTOs;

namespace ShopLuxe.Presentation.Facade.SiteEntities.Banner;

public interface IBannerFacade
{
    Task<OperationResult> CreateBanner(CreateBannerCommand command);
    Task<OperationResult> EditBanner(EditBannerCommand command);
    Task<OperationResult> DeleteBanner(Guid bannerId);

    Task<BannerDto?> GetBannerById(Guid id);
    Task<List<BannerDto>> GetBanners();
}