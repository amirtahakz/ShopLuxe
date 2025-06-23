using ShopLuxe.Application.SiteEntities.ShippingMethod.Create;
using ShopLuxe.Application.SiteEntities.ShippingMethod.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.SiteEntities.DTOs;

namespace ShopLuxe.Presentation.Facade.SiteEntities.ShippingMethods;

public interface IShippingMethodFacade
{
    Task<OperationResult> Create(CreateShippingMethodCommand command);
    Task<OperationResult> Edit(EditShippingMethodCommand command);
    Task<OperationResult> Delete(Guid id);


    Task<ShippingMethodDto?> GetShippingMethodById(Guid id);
    Task<List<ShippingMethodDto>> GetList();
}