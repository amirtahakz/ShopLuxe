using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Comments.Edit
{
    public record EditCommentCommand(Guid CommentId , Guid UserId , string Text) : IBaseCommand;
}
