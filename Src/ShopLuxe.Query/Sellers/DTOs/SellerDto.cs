using ShopLuxe.Common.Query;
using ShopLuxe.Domain.SellerAgg.Enums;

namespace ShopLuxe.Query.Sellers.DTOs;

public class SellerDto : BaseDto
{
    public Guid UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus Status { get; set; }
}