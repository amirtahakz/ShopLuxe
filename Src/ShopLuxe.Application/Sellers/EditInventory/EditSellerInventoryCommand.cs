using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Sellers.EditInventory
{
    public class EditSellerInventoryCommand : IBaseCommand
    {
        public EditSellerInventoryCommand(Guid sellerId, Guid inventoryId, int count, int price, int? discountPercentage)
        {
            SellerId = sellerId;
            InventoryId = inventoryId;
            Count = count;
            Price = price;
            DiscountPercentage = discountPercentage;
        }
        public Guid SellerId { get; private set; }
        public Guid InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int? DiscountPercentage { get; private set; }
    }
}
