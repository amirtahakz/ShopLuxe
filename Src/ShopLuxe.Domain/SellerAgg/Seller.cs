using ShopLuxe.Domain.UserAgg;
using ShopLuxe.Common.Domain;
using ShopLuxe.Common.Domain.Exceptions;
using ShopLuxe.Common.Domain.Utils;
using ShopLuxe.Domain.SellerAgg.Enums;
using ShopLuxe.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.SellerAgg
{
    public class Seller : BaseAggregateRoot
    {
        private Seller()
        {

        }
        public Seller(Guid userId, string shopName, string nationalCode, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Inventories = new List<SellerInventory>();

            if (domainService.IsValidSellerInformation(this) == false)
                throw new InvalidDomainDataException("اطلاعات نامعتبر است");

        }

        public Guid UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public List<SellerInventory> Inventories { get; private set; }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }
        public void Edit(string shopName, string nationalCode, SellerStatus status, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);
            if (nationalCode != NationalCode)
                if (domainService.NationalCodeExistInDataBase(nationalCode))
                    throw new InvalidDomainDataException("کدملی متعلق به شخص دیگری است");

            ShopName = shopName;
            NationalCode = nationalCode;
            Status = status;
        }

        public void AddInventory(SellerInventory inventory)
        {
            if (Inventories.Any(f => f.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException("این محصول قبلا ثبت شده است.");

            Inventories.Add(inventory);
        }
        public void EditInventory(Guid inventoryId, int count, int price, int? discountPercentage)
        {
            var currentInventory = Inventories.FirstOrDefault(g=>g.Id == inventoryId);
            if (currentInventory == null)
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");


            //TODO Check Inventories
            currentInventory.Edit(count, price, discountPercentage);
        }
        public void DeleteInventory(Guid inventoryId)
        {
            var oldInventory = Inventories.FirstOrDefault(g => g.Id == inventoryId);

            if(oldInventory == null)
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");


            Inventories.Remove(oldInventory);
        }
        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کد ملی نامعتبر است");
        }
    }
}
