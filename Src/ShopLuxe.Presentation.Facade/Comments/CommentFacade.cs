using MediatR;
using ShopLuxe.Query.Comments.GetByFilter;
using ShopLuxe.Query.Comments.GetById;
using ShopLuxe.Application.Comments.ChangeStatus;
using ShopLuxe.Application.Comments.Create;
using ShopLuxe.Application.Comments.Delete;
using ShopLuxe.Application.Comments.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Comments.DTOs;

namespace ShopLuxe.Presentation.Facade.Comments;

internal class CommentFacade : ICommentFacade
{
    private readonly IMediator _mediator;

    public CommentFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult<Guid>> CreateComment(CreateCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditComment(EditCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DeleteComment(DeleteCommentCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<CommentDto?> GetCommentById(Guid id)
    {
        return await _mediator.Send(new GetCommentByIdQuery(id));
    }

    public async Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams)
    {
        return await _mediator.Send(new GetCommentByFilterQuery(filterParams));
    }
}