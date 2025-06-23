using Microsoft.EntityFrameworkCore;
using ShopLuxe.Common.Query;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Query.Products;
using ShopLuxe.Query.Products.DTOs;

namespace ShopLuxe.Query.Products.GetByFilter;

public class GetProductByFilterQueryHandler : IQueryHandler<GetProductByFilterQuery, ProductFilterResult>
{
    private readonly ApplicationDbContext _context;

    public GetProductByFilterQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ProductFilterResult> Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Products.OrderByDescending(d => d.Id).AsQueryable();

        if (!string.IsNullOrWhiteSpace(@params.Slug))
            result = result.Where(r => r.Slug == @params.Slug);

        if (!string.IsNullOrWhiteSpace(@params.Title))
            result = result.Where(r => r.Title.Contains(@params.Title));

        if (@params.Id != null)
            result = result.Where(r => r.Id == @params.Id);

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new ProductFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take).Select(s => s.MapListData())
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}