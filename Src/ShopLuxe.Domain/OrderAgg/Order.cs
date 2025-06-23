using ShopLuxe.Common.Domain.Exceptions;
using ShopLuxe.Domain.OrderAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ShopLuxe.Domain.OrderAgg.Events;
using ShopLuxe.Domain.OrderAgg.ValueObjects;
using ShopLuxe.Domain.OrderAgg.Enums;
using ShopLuxe.Common.Domain;

namespace ShopLuxe.Domain.OrderAgg
{
    public class Order : BaseAggregateRoot
    {
        private Order()
        {

        }
        public Order(Guid userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }

        public Guid UserId { get; private set; }
        public OrderStatus Status { get; private set; }
        public OrderAddress? OrderAddress { get; private set; }
        public OrderShippingMethod? ShippingMethod { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public DateTime? LastUpdate { get; set; }
        public OrderDiscount? Discount { get; private set; }
        public int TotalPrice
        {
            get
            {
                var totalPrice = Items.Sum(f => f.TotalPrice);
                if (ShippingMethod != null)
                    totalPrice += ShippingMethod.ShippingCost;

                if (Discount != null)
                    totalPrice -= Discount.DiscountAmount;

                return totalPrice;
            }
        }
        public int ItemCount =>Items.Count;


        public void AddItem(OrderItem item)
        {
            ChangeOrderGuard();

            var oldItem = Items.FirstOrDefault(f => f.InventoryId == item.InventoryId);
            if (oldItem != null)
            {
                oldItem.ChangeCount(item.Count + oldItem.Count);
                return;
            }
            Items.Add(item);
        }

        public void RemoveItem(Guid itemId)
        {
            ChangeOrderGuard();

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem != null)
                Items.Remove(currentItem);
        }

        public void IncreaseItemCount(Guid itemId, int count)
        {
            ChangeOrderGuard();

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();

            currentItem.IncreaseCount(count);
        }

        public void DecreaseItemCount(Guid itemId, int count)
        {
            ChangeOrderGuard();

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();

            currentItem.DecreaseCount(count);
        }

        public void ChangeCountItem(Guid itemId, int newCount)
        {
            ChangeOrderGuard();

            var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
            if (currentItem == null)
                throw new NullOrEmptyDomainDataException();

            currentItem.ChangeCount(newCount);
        }

        public void Finally()
        {
            Status = OrderStatus.Finally;
            LastUpdate = DateTime.Now;
            AddDomainEvent(new OrderFinalized(Id));
        }
        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void Checkout(OrderAddress orderAddress, OrderShippingMethod shippingMethod)
        {
            ChangeOrderGuard();

            OrderAddress = orderAddress;
            ShippingMethod = shippingMethod;
        }

        public void ChangeOrderGuard()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidDomainDataException("امکان ویرایش این سفارش وجود ندارد");
        }
    }
}
