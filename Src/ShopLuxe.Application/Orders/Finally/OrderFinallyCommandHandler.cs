﻿using ShopLuxe.Common.Application;
using ShopLuxe.Domain.OrderAgg.Repository;

namespace ShopLuxe.Application.Orders.Finally
{
    public class OrderFinallyCommandHandler : IBaseCommandHandler<OrderFinallyCommand>
    {
        private readonly IOrderRepository _repository;
        public OrderFinallyCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(OrderFinallyCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetTracking(request.OrderId);
            if (order == null)
                return OperationResult.NotFound();

            order.Finally();
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
