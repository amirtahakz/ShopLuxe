using ShopLuxe.Application.SiteEntities.Sliders.Delete;
using MediatR;
using ShopLuxe.Query.SiteEntities.Sliders.GetById;
using ShopLuxe.Query.SiteEntities.Sliders.GetList;
using ShopLuxe.Application.SiteEntities.Sliders.Create;
using ShopLuxe.Application.SiteEntities.Sliders.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.SiteEntities.DTOs;

namespace ShopLuxe.Presentation.Facade.SiteEntities.Slider;

internal class SliderFacade : ISliderFacade
{
    private readonly IMediator _mediator;

    public SliderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> CreateSlider(CreateSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditSlider(EditSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DeleteSlider(Guid sliderId)
    {
        return await _mediator.Send(new DeleteSliderCommand(sliderId));
    }

    public async Task<SliderDto?> GetSliderById(Guid id)
    {
        return await _mediator.Send(new GetSliderByIdQuery(id));

    }
    public async Task<List<SliderDto>> GetSliders()
    {
        return await _mediator.Send(new GetSliderListQuery());
    }
}