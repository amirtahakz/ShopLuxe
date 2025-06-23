using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Sellers.AddInventory
{
    public class AddSellerInventoryCommand : IBaseCommand
    {
        public AddSellerInventoryCommand(Guid sellerId, Guid productId, int count,
            int price, int? percentageDiscount)
        {
            SellerId = sellerId;
            ProductId = productId;
            Count = count;
            Price = price;
            PercentageDiscount = percentageDiscount;
        }
        public Guid SellerId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? PercentageDiscount { get; private set; }
    }
}
