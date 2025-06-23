using MediatR;

namespace ShopLuxe.Common.Domain
{
    public class BaseDomainEvent : INotification
    {
        public DateTime CreationDate { get; protected set; }
        public BaseDomainEvent()
        {
            CreationDate = DateTime.Now;
        }
    }
}
