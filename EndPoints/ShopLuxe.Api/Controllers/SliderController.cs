using ShopLuxe.Api.Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopLuxe.Application.SiteEntities.Sliders.Create;
using ShopLuxe.Application.SiteEntities.Sliders.Edit;
using ShopLuxe.Common.AspNetCore;
using ShopLuxe.Domain.RoleAgg.Enums;
using ShopLuxe.Presentation.Facade.SiteEntities.Slider;
using ShopLuxe.Query.SiteEntities.DTOs;

namespace ShopLuxe.Api.Controllers;


[PermissionChecker(Permission.CRUD_Slider)]
public class SliderController : ApiController
{
    private readonly ISliderFacade _facade;


    public SliderController(ISliderFacade facade)
    {
        _facade = facade;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ApiResult<List<SliderDto>>> GetList()
    {
        var result = await _facade.GetSliders();
        return QueryResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<SliderDto?>> GetById(Guid id)
    {
        var result = await _facade.GetSliderById(id);
        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> Create([FromForm] CreateSliderCommand command)
    {
        var result = await _facade.CreateSlider(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> Edit([FromForm] EditSliderCommand command)
    {
        var result = await _facade.EditSlider(command);
        return CommandResult(result);
    }

    [HttpDelete("{sliderId}")]
    public async Task<ApiResult> Delete(Guid sliderId)
    {
        var result = await _facade.DeleteSlider(sliderId);
        return CommandResult(result);
    }
}