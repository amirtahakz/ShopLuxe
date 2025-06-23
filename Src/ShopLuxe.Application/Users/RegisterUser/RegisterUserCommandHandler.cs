using ShopLuxe.Domain.UserAgg.Services;
using ShopLuxe.Domain.UserAgg.Repository;
using ShopLuxe.Domain.UserAgg;
using ShopLuxe.Common.Application.SecurityUtil;
using ShopLuxe.Common.Application;

namespace ShopLuxe.Application.Users.RegisterUser
{
    internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserDomainService _domainService;

        public RegisterUserCommandHandler(IUserRepository repository, IUserDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.RegisterUser(request.PhoneNumber, Sha256Hasher.Hash(request.Password), _domainService);

            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
