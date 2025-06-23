using Microsoft.EntityFrameworkCore;
using ShopLuxe.Common.Query;
using ShopLuxe.Infrastructure.Persistent.Dapper;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Query.Orders;
using ShopLuxe.Query.Orders.DTOs;

namespace ShopLuxe.Query.Orders.GetById;

public record GetOrderByIdQuery(Guid OrderId) : IQuery<OrderDto>;

public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly ApplicationDbContext _Context;
    private readonly  DapperContext _dapperContext;

    public GetOrderByIdQueryHandler(ApplicationDbContext context, DapperContext dapperContext)
    {
        _Context = context;
        _dapperContext = dapperContext;
    }
    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _Context.Orders.FirstOrDefaultAsync(o => o.Id == request.OrderId);

        if (order == null)
            return null;

        var orderDto = order.Map();
        orderDto.UserFullName = await _Context.Users.Where(f => f.Id == orderDto.UserId)
            .Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken);

        orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
        return orderDto;
    }
}