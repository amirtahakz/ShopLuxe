using ShopLuxe.Domain.SellerAgg;
using ShopLuxe.Query.Sellers.DTOs;
namespace ShopLuxe.Query.Sellers;

public static class SellerMapper
{
    public static SellerDto Map(this Seller seller)
    {
        if (seller == null)
            return null;

        return new SellerDto()
        {
            Id = seller.Id,
            CreationDate = seller.CreationDate,
            Status = seller.Status,
            NationalCode = seller.NationalCode,
            ShopName = seller.ShopName,
            UserId = seller.UserId
        };
    }
}