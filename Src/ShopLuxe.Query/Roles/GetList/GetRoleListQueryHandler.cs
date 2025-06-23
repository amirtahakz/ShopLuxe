using Microsoft.EntityFrameworkCore;
using ShopLuxe.Common.Query;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Query.Roles.DTOs;

namespace ShopLuxe.Query.Roles.GetList;

public class GetRoleListQueryHandler : IQueryHandler<GetRoleListQuery, List<RoleDto>>
{
    private readonly ApplicationDbContext _context;

    public GetRoleListQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        return await _context.Roles.Select(role => new RoleDto()
        {
            Id = role.Id,
            CreationDate = role.CreationDate,
            Permissions = role.Permissions.Select(s => s.Permission).ToList(),
            Title = role.Title
        }).ToListAsync(cancellationToken);
    }
}