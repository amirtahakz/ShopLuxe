using ShopLuxe.Application.Orders.AddItem;
using ShopLuxe.Application.Orders.Checkout;
using ShopLuxe.Application.Orders.DecreaseItemCount;
using ShopLuxe.Application.Orders.Finally;
using ShopLuxe.Application.Orders.IncreaseItemCount;
using ShopLuxe.Application.Orders.RemoveItem;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Orders.DTOs;


namespace ShopLuxe.Presentation.Facade.Orders;

public interface IOrderFacade
{
    Task<OperationResult> AddOrderItem(AddOrderItemCommand command);
    Task<OperationResult> OrderCheckOut(CheckoutOrderCommand command);
    Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command);
    Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command);
    Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command);
    Task<OperationResult> FinallyOrder(OrderFinallyCommand command);
    Task<OperationResult> SendOrder(Guid orderId);



    Task<OrderDto?> GetOrderById(Guid orderId);
    Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams);
    Task<OrderDto?> GetCurrentOrder(Guid userId);
}