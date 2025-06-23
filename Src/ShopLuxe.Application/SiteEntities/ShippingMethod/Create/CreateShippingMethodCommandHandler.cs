using ShopLuxe.Common.Application;
using ShopLuxe.Domain.SiteEntities.Repositories;

namespace ShopLuxe.Application.SiteEntities.ShippingMethod.Create
{
    public class CreateShippingMethodCommandHandler : IBaseCommandHandler<CreateShippingMethodCommand>
    {
        private readonly IShippingMethodRepository _repository;

        public CreateShippingMethodCommandHandler(IShippingMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateShippingMethodCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(new Domain.SiteEntities.ShippingMethod(request.Cost, request.Title));
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
