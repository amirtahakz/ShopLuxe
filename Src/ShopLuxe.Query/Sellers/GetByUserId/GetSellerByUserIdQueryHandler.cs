using Microsoft.EntityFrameworkCore;
using ShopLuxe.Common.Query;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Query.Sellers;
using ShopLuxe.Query.Sellers.DTOs;

namespace ShopLuxe.Query.Sellers.GetByUserId;

public class GetSellerByUserIdQueryHandler : IQueryHandler<GetSellerByUserIdQuery, SellerDto?>
{
    private readonly ApplicationDbContext _context;

    public GetSellerByUserIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<SellerDto?> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
    {
        var seller = await _context.Sellers.FirstOrDefaultAsync(f => f.UserId == request.UserId,
            cancellationToken: cancellationToken);
        return seller.Map();
    }
}