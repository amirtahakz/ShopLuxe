using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopLuxe.Common.Domain;

namespace ShopLuxe.Domain.FavoriteAgg
{
    public class Favorite : BaseAggregateRoot
    {
        public Favorite(Guid userId, Guid productId)
        {
            UserId = userId;
            ProductId = productId;
        }
        public Favorite()
        {
            
        }

        public Guid UserId { get; private set; }

        public Guid ProductId { get; private set; }
    }
}
