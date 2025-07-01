using ShopLuxe.Common.Application;
using ShopLuxe.Domain.UserAgg;
using ShopLuxe.Domain.UserAgg.Repository;

namespace ShopLuxe.Application.Users.EditRole
{
    public class EditUserRoleCommandHandler : IBaseCommandHandler<EditUserRoleCommand>
    {
        private readonly IUserRepository _repository;

        public EditUserRoleCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditUserRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            var roles = new List<UserRole>();
            request.Roles.ForEach(f =>
            {
                roles.Add(new UserRole(f.RoleId));
            });
            user.SetRoles(roles);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
