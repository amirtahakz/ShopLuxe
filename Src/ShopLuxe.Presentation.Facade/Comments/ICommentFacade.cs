using ShopLuxe.Application.Comments.ChangeStatus;
using ShopLuxe.Application.Comments.Create;
using ShopLuxe.Application.Comments.Delete;
using ShopLuxe.Application.Comments.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Comments.DTOs;

namespace ShopLuxe.Presentation.Facade.Comments;

public interface ICommentFacade
{
    Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command);
    Task<OperationResult<Guid>> CreateComment(CreateCommentCommand command);
    Task<OperationResult> EditComment(EditCommentCommand command);
    Task<OperationResult> DeleteComment(DeleteCommentCommand command);


    Task<CommentDto?> GetCommentById(Guid id);
    Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams);
}