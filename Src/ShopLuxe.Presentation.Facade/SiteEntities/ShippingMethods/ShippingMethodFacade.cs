using ShopLuxe.Application.SiteEntities.ShippingMethod.Delete;
using MediatR;
using ShopLuxe.Query.SiteEntities.ShippingMethods.GetById;
using ShopLuxe.Query.SiteEntities.ShippingMethods.GetList;
using ShopLuxe.Application.SiteEntities.ShippingMethod.Create;
using ShopLuxe.Application.SiteEntities.ShippingMethod.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.SiteEntities.DTOs;

namespace ShopLuxe.Presentation.Facade.SiteEntities.ShippingMethods;

internal class ShippingMethodFacade : IShippingMethodFacade
{
    private readonly IMediator _mediator;

    public ShippingMethodFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateShippingMethodCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditShippingMethodCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> Delete(Guid id)
    {
        return await _mediator.Send(new DeleteShippingMethodCommand(id));

    }

    public async Task<ShippingMethodDto?> GetShippingMethodById(Guid id)
    {
        return await _mediator.Send(new GetShippingMethodByIdQuery(id));

    }

    public async Task<List<ShippingMethodDto>> GetList()
    {
        return await _mediator.Send(new GetShippingMethodsByListQuery());

    }
}