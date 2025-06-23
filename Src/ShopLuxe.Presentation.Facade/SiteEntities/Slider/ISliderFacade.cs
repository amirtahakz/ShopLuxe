using ShopLuxe.Application.SiteEntities.Sliders.Create;
using ShopLuxe.Application.SiteEntities.Sliders.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.SiteEntities.DTOs;

namespace ShopLuxe.Presentation.Facade.SiteEntities.Slider;

public interface ISliderFacade
{
    Task<OperationResult> CreateSlider(CreateSliderCommand command);
    Task<OperationResult> EditSlider(EditSliderCommand command);
    Task<OperationResult> DeleteSlider(Guid sliderId);

    Task<SliderDto?> GetSliderById(Guid id);
    Task<List<SliderDto>> GetSliders();
}