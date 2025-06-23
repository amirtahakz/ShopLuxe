using MediatR;
using ShopLuxe.Common.Domain;

namespace ShopLuxe.Domain.OrderAgg.Events;

public class OrderFinalized : BaseDomainEvent
{
    public OrderFinalized(Guid orderId)
    {
        OrderId = orderId;
    }

    public Guid OrderId { get; private set; }
}