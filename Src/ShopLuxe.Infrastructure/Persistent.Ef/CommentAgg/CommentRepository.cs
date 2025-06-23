using ShopLuxe.Domain.CommentAgg;
using ShopLuxe.Domain.CommentAgg.Repository;
using ShopLuxe.Infrastructure._Utilities;

namespace ShopLuxe.Infrastructure.Persistent.Ef.CommentAgg;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task DeleteAndSave(Comment comment)
    {
        Context.Remove(comment);
        await Context.SaveChangesAsync();
    }
}