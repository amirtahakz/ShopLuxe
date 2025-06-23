using ShopLuxe.Common.Domain.Exceptions;
using ShopLuxe.Common.Domain;
using ShopLuxe.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.UserAgg
{
    public class Wallet : BaseEntity
    {
        private Wallet()
        {

        }
        public Wallet(int price, string description, bool isFinally, WalletType type)
        {
            if (price < 500)
                throw new InvalidDomainDataException();

            Price = price;
            Description = description;
            IsFinally = isFinally;
            Type = type;
            if (isFinally)
                FinallyDate = DateTime.Now;
        }

        public int Price { get; private set; }
        public WalletType Type { get; private set; }
        public string Description { get; private set; }
        public Guid UserId { get; internal set; }
        public bool IsFinally { get; private set; }
        public DateTime? FinallyDate { get; private set; }

        public void Finally(string refCode)
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
            Description += $" کد پیگیری : {refCode}";
        }

        public void Finally()
        {
            IsFinally = true;
            FinallyDate = DateTime.Now;
        }
    }
}
