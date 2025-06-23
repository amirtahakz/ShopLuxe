using ShopLuxe.Application.Orders.SendOrder;
using MediatR;
using ShopLuxe.Query.Orders.GetByFilter;
using ShopLuxe.Query.Orders.GetById;
using ShopLuxe.Query.Orders.GetCurrent;
using ShopLuxe.Application.Orders.AddItem;
using ShopLuxe.Application.Orders.Checkout;
using ShopLuxe.Application.Orders.DecreaseItemCount;
using ShopLuxe.Application.Orders.Finally;
using ShopLuxe.Application.Orders.IncreaseItemCount;
using ShopLuxe.Application.Orders.RemoveItem;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Orders.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopLuxe.Presentation.Facade.Orders;

internal class OrderFacade : IOrderFacade
{
    private readonly IMediator _mediator;

    public OrderFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddOrderItem(AddOrderItemCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> OrderCheckOut(CheckoutOrderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> FinallyOrder(OrderFinallyCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> SendOrder(Guid orderId)
    {
        return await _mediator.Send(new SendOrderCommand(orderId));

    }

    public async Task<OrderDto?> GetOrderById(Guid orderId)
    {
        return await _mediator.Send(new GetOrderByIdQuery(orderId));
    }

    public async Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams)
    {
        return await _mediator.Send(new GetOrderByFilterQuery(filterParams));
    }

    public async Task<OrderDto?> GetCurrentOrder(Guid userId)
    {
        return await _mediator.Send(new GetCurrentUserOrderQuery(userId));
    }
}