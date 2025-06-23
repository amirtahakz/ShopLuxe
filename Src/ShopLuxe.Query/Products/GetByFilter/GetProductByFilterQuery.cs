using ShopLuxe.Query.Orders.DTOs;
using ShopLuxe.Query.Orders;
using ShopLuxe.Common.Query;
using ShopLuxe.Query.Products.DTOs;

namespace ShopLuxe.Query.Products.GetByFilter;

public class GetProductByFilterQuery : QueryFilter<ProductFilterResult , ProductFilterParams>
{
    public GetProductByFilterQuery(ProductFilterParams filterParams) : base(filterParams)
    {
        
    }
}