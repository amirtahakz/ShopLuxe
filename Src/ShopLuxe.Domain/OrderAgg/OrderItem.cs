using ShopLuxe.Common.Domain.Exceptions;
using ShopLuxe.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.OrderAgg
{
    public class OrderItem : BaseEntity
    {
        private OrderItem()
        {

        }
        public OrderItem(Guid inventoryId, int count, int price)
        {
            CountGuard(count);
            PriceGuard(price);
            InventoryId = inventoryId;
            Count = count;
            Price = price;
        }

        public Guid OrderId { get; internal set; }
        public Guid InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int TotalPrice => Price*Count;


        public void IncreaseCount(int count)
        {
            Count += count;
        }

        public void DecreaseCount(int count)
        {
            if (Count == 1)
                return;
            if (Count - count <= 0)
                return;

            Count -= count;
        }

        public void ChangeCount(int newCount)
        {
            CountGuard(newCount);

            Count = newCount;
        }

        public void SetPrice(int newPrice)
        {
            PriceGuard(newPrice);
            Price = newPrice;
        }

        public void PriceGuard(int newPrice)
        {
            if (newPrice < 1)
                throw new InvalidDomainDataException("مبلغ کالا نامعتبر است");
        }

        public void CountGuard(int count)
        {
            if (count < 1)
                throw new InvalidDomainDataException();
        }
    }
}
