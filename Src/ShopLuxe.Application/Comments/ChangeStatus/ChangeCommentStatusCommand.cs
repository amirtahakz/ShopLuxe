using ShopLuxe.Common.Application;
using ShopLuxe.Domain.CommentAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Comments.ChangeStatus
{
    public record ChangeCommentStatusCommand(Guid Id, CommentStatus Status) : IBaseCommand;
}
