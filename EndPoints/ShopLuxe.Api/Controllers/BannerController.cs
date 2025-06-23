using ShopLuxe.Domain.RoleAgg.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopLuxe.Application.SiteEntities.Banners.Create;
using ShopLuxe.Application.SiteEntities.Banners.Edit;
using ShopLuxe.Common.AspNetCore;
using ShopLuxe.Presentation.Facade.SiteEntities.Banner;
using ShopLuxe.Query.SiteEntities.DTOs;

namespace ShopLuxe.Api.Controllers;

//[PermissionChecker(Permission.CRUD_Banner)]
public class BannerController : ApiController
{
    private readonly IBannerFacade _facade;


    public BannerController(IBannerFacade facade)
    {
        _facade = facade;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ApiResult<List<BannerDto>>> GetList()
    {
        var result = await _facade.GetBanners();
        return QueryResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<BannerDto?>> GetById(Guid id)
    {
        var result = await _facade.GetBannerById(id);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> Create([FromForm] CreateBannerCommand command)
    {
        var result = await _facade.CreateBanner(command);
        return CommandResult(result);
    }
    [HttpPut]
    public async Task<ApiResult> Edit([FromForm] EditBannerCommand command)
    {
        var result = await _facade.EditBanner(command);
        return CommandResult(result);
    }

    [HttpDelete("{bannerId}")]
    public async Task<ApiResult> Delete(Guid bannerId)
    {
        var result = await _facade.DeleteBanner(bannerId);
        return CommandResult(result);
    }
}