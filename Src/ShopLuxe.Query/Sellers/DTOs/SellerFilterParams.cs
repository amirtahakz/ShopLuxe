using ShopLuxe.Common.Query.Filter;

namespace ShopLuxe.Query.Sellers.DTOs;

public class SellerFilterParams : BaseFilterParam
{
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
}