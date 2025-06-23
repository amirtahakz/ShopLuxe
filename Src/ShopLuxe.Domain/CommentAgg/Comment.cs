using ShopLuxe.Common.Domain;
using ShopLuxe.Common.Domain.Exceptions;
using ShopLuxe.Domain.CommentAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Domain.CommentAgg
{
    public class Comment : BaseAggregateRoot
    {
        private Comment()
        {

        }
        public Comment(Guid userId, Guid productId, string text)
        {
            NullOrEmptyDomainDataException.CheckString(text, nameof(text));

            UserId = userId;
            ProductId = productId;
            Text = text;
            Status = CommentStatus.Pending;
        }

        public Guid UserId { get;private set; }
        public Guid ProductId { get;private set; }
        public string Text { get;private set; }
        public CommentStatus Status { get;private set; }
        public DateTime UpdateDate { get; private set; }

        public void Edit(string text)
        {
            NullOrEmptyDomainDataException.CheckString(text, nameof(text));

            Text = text;
            UpdateDate = DateTime.Now;
        }

        public void ChangeStatus(CommentStatus status)
        {
            Status = status;
            UpdateDate = DateTime.Now;
        }
    }
}
