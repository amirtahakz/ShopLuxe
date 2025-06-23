using MediatR;
using ShopLuxe.Query.Sellers.Inventories.GetById;
using ShopLuxe.Query.Sellers.Inventories.GetByProductId;
using ShopLuxe.Query.Sellers.Inventories.GetList;
using ShopLuxe.Application.Sellers.AddInventory;
using ShopLuxe.Application.Sellers.EditInventory;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Sellers.DTOs;

namespace ShopLuxe.Presentation.Facade.Sellers.Inventories;

internal class SellerInventoryFacade : ISellerInventoryFacade
{
    private readonly IMediator _mediator;

    public SellerInventoryFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditInventory(EditSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<InventoryDto?> GetById(Guid inventoryId)
    {
        return await _mediator.Send(new GetSellerInventoryByIdQuery(inventoryId));
    }

    public async Task<List<InventoryDto>> GetList(Guid sellerId)
    {
        return await _mediator.Send(new GetInventoriesQuery(sellerId));
    }

    public async Task<List<InventoryDto>> GetByProductId(Guid productId)
    {
        return await _mediator.Send(new GetInventoriesByProductIdQuery(productId));
    }
}