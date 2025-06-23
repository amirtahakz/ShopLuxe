using ShopLuxe.Common.Application;
using ShopLuxe.Domain.CommentAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Comments.Delete
{
    public class DeleteCommentCommandHandler : IBaseCommandHandler<DeleteCommentCommand>
    {
        private readonly ICommentRepository _repository;

        public DeleteCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetTracking(request.CommentId);
            if (comment == null || comment.UserId != request.UserId)
                return OperationResult.NotFound();

            await _repository.DeleteAndSave(comment);
            return OperationResult.Success();
        }
    }
}
