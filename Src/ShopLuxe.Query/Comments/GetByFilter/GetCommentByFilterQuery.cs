using ShopLuxe.Common.Query;
using ShopLuxe.Query.Comments.DTOs;

namespace ShopLuxe.Query.Comments.GetByFilter;


public class GetCommentByFilterQuery : QueryFilter<CommentFilterResult, CommentFilterParams>
{
    public GetCommentByFilterQuery(CommentFilterParams filterParams) : base(filterParams)
    {
    }
}