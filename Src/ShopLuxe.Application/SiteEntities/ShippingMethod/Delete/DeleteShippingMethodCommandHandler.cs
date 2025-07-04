﻿using ShopLuxe.Common.Application;
using ShopLuxe.Domain.SiteEntities.Repositories;

namespace ShopLuxe.Application.SiteEntities.ShippingMethod.Delete
{
    public class DeleteShippingMethodCommandHandler : IBaseCommandHandler<DeleteShippingMethodCommand>
    {
        private readonly IShippingMethodRepository _repository;

        public DeleteShippingMethodCommandHandler(IShippingMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteShippingMethodCommand request, CancellationToken cancellationToken)
        {
            var shipping = await _repository.GetTracking(request.Id);
            if (shipping == null)
                return OperationResult.NotFound();

            _repository.Delete(shipping);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
