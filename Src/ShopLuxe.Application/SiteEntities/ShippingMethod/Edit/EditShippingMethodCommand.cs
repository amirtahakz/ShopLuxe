using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.SiteEntities.ShippingMethod.Edit
{
    public class EditShippingMethodCommand : IBaseCommand
    {
        public EditShippingMethodCommand(Guid id, string title, int cost)
        {
            Id = id;
            Title = title;
            Cost = cost;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public int Cost { get; private set; }
    }
}
