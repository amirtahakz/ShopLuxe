using ShopLuxe.Common.Query;
using ShopLuxe.Query.Products.DTOs;

namespace ShopLuxe.Query.Products.GetForShop;

public class GetProductsForShopQuery : QueryFilter<ProductShopResult, ProductShopFilterParam>
{
    public GetProductsForShopQuery(ProductShopFilterParam filterParams) : base(filterParams)
    {
    }
}