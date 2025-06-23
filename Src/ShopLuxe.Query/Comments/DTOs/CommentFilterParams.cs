using ShopLuxe.Common.Query.Filter;
using ShopLuxe.Domain.CommentAgg.Enums;

namespace ShopLuxe.Query.Comments.DTOs;

public class CommentFilterParams : BaseFilterParam
{
    public Guid? UserId { get; set; }
    public Guid? ProductId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public CommentStatus? CommentStatus { get; set; }

}