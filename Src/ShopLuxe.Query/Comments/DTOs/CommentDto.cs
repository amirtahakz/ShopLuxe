using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopLuxe.Common.Query;
using ShopLuxe.Domain.CommentAgg.Enums;

namespace ShopLuxe.Query.Comments.DTOs
{
    public class CommentDto : BaseDto
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
