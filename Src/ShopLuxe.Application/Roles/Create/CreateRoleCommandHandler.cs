﻿using ShopLuxe.Common.Application;
using ShopLuxe.Domain.RoleAgg;
using ShopLuxe.Domain.RoleAgg.Repository;

namespace ShopLuxe.Application.Roles.Create
{
    public class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public CreateRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var permissions = new List<RolePermission>();
            request.Permissions.ForEach(f =>
            {
                permissions.Add(new RolePermission(f));
            });
            var role = new Role(request.Title, permissions);
            _repository.Add(role);
            await _repository.Save();

            return OperationResult.Success();
        }
    }
}
