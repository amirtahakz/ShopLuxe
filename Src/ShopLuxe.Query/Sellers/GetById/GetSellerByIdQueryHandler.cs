using Microsoft.EntityFrameworkCore;
using ShopLuxe.Common.Query;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Query.Sellers;
using ShopLuxe.Query.Sellers.DTOs;

namespace ShopLuxe.Query.Sellers.GetById;

public class GetSellerByIdQueryHandler : IQueryHandler<GetSellerByIdQuery, SellerDto?>
{
    private ApplicationDbContext _shopContext;

    public GetSellerByIdQueryHandler(ApplicationDbContext shopContext)
    {
        _shopContext = shopContext;
    }

    public async Task<SellerDto?> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _shopContext.Sellers.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken: cancellationToken);
        return seller.Map();
    }
}