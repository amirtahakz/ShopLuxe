using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopLuxe.Domain.SellerAgg.Services;
using ShopLuxe.Domain.SellerAgg.Repository;
using ShopLuxe.Domain.SellerAgg;

namespace ShopLuxe.Application.Sellers
{
    public class SellerDomainService : ISellerDomainService
    {
        private readonly ISellerRepository _repository;

        public SellerDomainService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public bool IsValidSellerInformation(Seller seller)
        {
            var sellerIsExist = _repository
                .Exists(r => r.NationalCode == seller.NationalCode || r.UserId == seller.UserId);
            return !sellerIsExist;
        }

        public bool NationalCodeExistInDataBase(string nationalCode)
        {
            return _repository.Exists(r => r.NationalCode == nationalCode);
        }
    }
}
