using ShopLuxe.Common.Domain.ValueObjects;
using ShopLuxe.Domain.UserAgg;
using ShopLuxe.Common.Application;
using ShopLuxe.Common.Application.SecurityUtil;
using ShopLuxe.Domain.UserAgg.Repository;
using ShopLuxe.Domain.UserAgg.Services;

namespace ShopLuxe.Application.Users.Create
{
    public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IUserDomainService _userDomainService;
        public CreateUserCommandHandler(IUserRepository repository, IUserDomainService userDomainService)
        {
            _repository = repository;
            _userDomainService = userDomainService;
        }

        public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = Sha256Hasher.Hash(request.Password);
            var user = new User(request.Name, request.Family, request.PhoneNumber
                , request.Email, password, request.Gender, _userDomainService);

            _repository.Add(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
