﻿using ShopLuxe.Common.Domain.ValueObjects;
using ShopLuxe.Domain.OrderAgg.ValueObjects;
using ShopLuxe.Domain.OrderAgg;
using ShopLuxe.Domain.SiteEntities.Repositories;
using ShopLuxe.Domain.OrderAgg.Repository;
using ShopLuxe.Common.Application;

namespace ShopLuxe.Application.Orders.Checkout
{
    public class CheckoutOrderCommandHandler : IBaseCommandHandler<CheckoutOrderCommand>
    {
        private readonly IOrderRepository _repository;
        private IShippingMethodRepository _shippingMethodRepository;
        public CheckoutOrderCommandHandler(IOrderRepository repository, IShippingMethodRepository shippingMethodRepository)
        {
            _repository = repository;
            _shippingMethodRepository = shippingMethodRepository;
        }

        public async Task<OperationResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var currentOrder = await _repository.GetCurrentUserOrder(request.UserId);
            if (currentOrder == null)
                return OperationResult.NotFound();

            var address = new OrderAddress(request.Shire, request.City, request.PostalCode,
                request.PostalAddress, request.PhoneNumber, request.Name,
                request.Family, request.NationalCode);

            var shippingMethod = await _shippingMethodRepository.GetAsync(request.ShippingMethodId);
            if (shippingMethod == null)
                return OperationResult.Error();


            currentOrder.Checkout(address, new OrderShippingMethod(shippingMethod.Title, shippingMethod.Cost));

            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
