using Microsoft.EntityFrameworkCore;
using ShopLuxe.Common.Query;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Query.Comments;
using ShopLuxe.Query.Comments.DTOs;

namespace ShopLuxe.Query.Comments.GetById;

public class GetCommentByIdQueryHandler : IQueryHandler<GetCommentByIdQuery, CommentDto?>
{
    private readonly ApplicationDbContext _context;

    public GetCommentByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var res = await _context.Comments.FirstOrDefaultAsync(f => f.Id == request.CommentId);
        return res.Map();
    }
}