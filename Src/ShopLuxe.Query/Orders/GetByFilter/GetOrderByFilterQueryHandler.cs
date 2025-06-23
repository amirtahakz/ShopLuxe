using Microsoft.EntityFrameworkCore;
using ShopLuxe.Common.Query;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Query.Orders;
using ShopLuxe.Query.Orders.DTOs;

namespace ShopLuxe.Query.Orders.GetByFilter;

public class GetOrderByFilterQueryHandler : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
{
    private readonly ApplicationDbContext _context;

    public GetOrderByFilterQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Orders.OrderByDescending(d => d.Id).AsQueryable();

        if (@params.Status != null)
            result = result.Where(r => r.Status == @params.Status);

        if (@params.UserId != null)
            result = result.Where(r => r.UserId == @params.UserId);

        if (@params.StartDate != null)
            result = result.Where(r => r.CreationDate.Date >= @params.StartDate.Value.Date);

        if (@params.EndDate != null)
            result = result.Where(r => r.CreationDate.Date <= @params.EndDate.Value.Date);


        var skip = (@params.PageId - 1) * @params.Take;
        var model = new OrderFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(order => order.MapFilterData(_context))
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}