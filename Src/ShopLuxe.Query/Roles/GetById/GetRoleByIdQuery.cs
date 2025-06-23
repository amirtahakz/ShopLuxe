using Microsoft.EntityFrameworkCore;
using ShopLuxe.Common.Query;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Query.Roles.DTOs;

namespace ShopLuxe.Query.Roles.GetById;

public record GetRoleByIdQuery(Guid RoleId) : IQuery<RoleDto?>;

public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto?>
{
    private readonly ApplicationDbContext _context;

    public GetRoleByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(f => f.Id == request.RoleId, cancellationToken: cancellationToken);
        if (role == null)
            return null;

        return new RoleDto()
        {
            Id = role.Id,
            CreationDate = role.CreationDate,
            Permissions = role.Permissions.Select(s => s.Permission).ToList(),
            Title = role.Title
        };
    }
}