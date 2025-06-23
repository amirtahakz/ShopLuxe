using ShopLuxe.Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Comments.Create
{
    public record CreateCommentCommand(Guid UserId, Guid ProductId, string Text) : IBaseCommand<Guid>;
}
