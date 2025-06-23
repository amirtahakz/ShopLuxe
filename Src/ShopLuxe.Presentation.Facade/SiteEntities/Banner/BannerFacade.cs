using ShopLuxe.Application.SiteEntities.Banners.Delete;
using MediatR;
using ShopLuxe.Query.SiteEntities.Banners.GetById;
using ShopLuxe.Query.SiteEntities.Banners.GetList;
using ShopLuxe.Application.SiteEntities.Banners.Create;
using ShopLuxe.Application.SiteEntities.Banners.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.SiteEntities.DTOs;

namespace ShopLuxe.Presentation.Facade.SiteEntities.Banner;

internal class BannerFacade : IBannerFacade
{
    private readonly IMediator _mediator;

    public BannerFacade(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<OperationResult> CreateBanner(CreateBannerCommand command)
    {
        return await _mediator.Send(command);
    }
    public async Task<OperationResult> EditBanner(EditBannerCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DeleteBanner(Guid bannerId)
    {
        return await _mediator.Send(new DeleteBannerCommand(bannerId));
    }

    public async Task<BannerDto?> GetBannerById(Guid id)
    {
        return await _mediator.Send(new GetBannerByIdQuery(id));

    }

    public async Task<List<BannerDto>> GetBanners()
    {
        return await _mediator.Send(new GetBannerListQuery());

    }


}