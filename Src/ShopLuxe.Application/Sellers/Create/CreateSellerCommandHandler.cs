using ShopLuxe.Domain.SellerAgg;
using ShopLuxe.Domain.SellerAgg.Services;
using ShopLuxe.Domain.SellerAgg.Repository;
using ShopLuxe.Common.Application;

namespace ShopLuxe.Application.Sellers.Create
{
    public class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
    {
        private readonly ISellerRepository _repository;
        private readonly ISellerDomainService _domainService;
        public CreateSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
        {
            var seller = new Seller(request.UserId, request.ShopName, request.NationalCode, _domainService);

            _repository.Add(seller);
            await _repository.Save();

            return OperationResult.Success();
        }
    }
}
