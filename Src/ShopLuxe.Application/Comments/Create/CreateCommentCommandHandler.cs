using ShopLuxe.Domain.CommentAgg;
using ShopLuxe.Common.Application;
using ShopLuxe.Domain.CommentAgg.Repository;

namespace ShopLuxe.Application.Comments.Create
{
    public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand, Guid>
    {
        private readonly ICommentRepository _repository;

        public CreateCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<Guid>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.UserId , request.ProductId , request.Text);

            await _repository.AddAsync(comment);
            await _repository.Save();

            return OperationResult<Guid>.Success(comment.Id);
        }
    }
}
