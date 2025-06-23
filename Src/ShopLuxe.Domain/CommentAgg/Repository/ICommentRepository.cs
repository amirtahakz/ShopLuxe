using ShopLuxe.Domain.CategoryAgg;
using ShopLuxe.Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.CommentAgg.Repository
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task DeleteAndSave(Comment comment);
    }
}
