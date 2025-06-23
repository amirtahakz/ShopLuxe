using Microsoft.EntityFrameworkCore;
using ShopLuxe.Common.Query;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Query.Products;
using ShopLuxe.Query.Products.DTOs;

namespace ShopLuxe.Query.Products.GetById;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly ApplicationDbContext _context;

    public GetProductByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var res = await _context.Products.FirstOrDefaultAsync(p=>p.Id == request.Id ,cancellationToken);

        var model = res.Map();


        if (model == null)
            return null;

        await model.SetCategories(_context);
        return model;
    }
}