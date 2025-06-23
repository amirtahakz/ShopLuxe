using ShopLuxe.Common.Query;
using ShopLuxe.Query.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Query.Comments.GetById
{
    public record GetCommentByIdQuery(Guid CommentId) : IQuery<CommentDto?>;
}
