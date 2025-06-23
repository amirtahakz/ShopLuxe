using ShopLuxe.Common.Query;
using ShopLuxe.Query.Sellers.DTOs;

namespace ShopLuxe.Query.Sellers.GetById;

public class GetSellerByIdQuery : IQuery<SellerDto>
{
    public GetSellerByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}