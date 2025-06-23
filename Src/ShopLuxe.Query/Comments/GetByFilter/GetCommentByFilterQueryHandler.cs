using Microsoft.EntityFrameworkCore;
using ShopLuxe.Common.Query;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Query.Comments;
using ShopLuxe.Query.Comments.DTOs;

namespace ShopLuxe.Query.Comments.GetByFilter;

public class GetCommentByFilterQueryHandler : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
{
    private readonly ApplicationDbContext _context;

    public GetCommentByFilterQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;

        var result = _context.Comments.OrderByDescending(d => d.CreationDate).AsQueryable();


        if (@params.ProductId != null)
            result = result.Where(r => r.ProductId == @params.ProductId);

        if (@params.CommentStatus != null)
            result = result.Where(r => r.Status == @params.CommentStatus);

        if (@params.UserId != null)
            result = result.Where(r => r.UserId == @params.UserId);

        if (@params.StartDate != null)
            result = result.Where(r => r.CreationDate.Date >= @params.StartDate.Value.Date);

        if (@params.EndDate != null)
            result = result.Where(r => r.CreationDate.Date <= @params.EndDate.Value.Date);



        var skip = (@params.PageId - 1) * @params.Take;
        var model = new CommentFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(comment => comment.MapFilterComment())
                .ToListAsync(cancellationToken),
            FilterParams = @params
        };
        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}