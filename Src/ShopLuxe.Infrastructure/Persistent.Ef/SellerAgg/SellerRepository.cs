using Dapper;
using Microsoft.EntityFrameworkCore;
using ShopLuxe.Infrastructure.Persistent.Dapper;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Infrastructure._Utilities;
using ShopLuxe.Domain.SellerAgg.Repository;
using ShopLuxe.Domain.SellerAgg;

namespace ShopLuxe.Infrastructure.Persistent.Ef.SellerAgg;

internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
{
    private readonly DapperContext _dapperContext;
    public SellerRepository(ApplicationDbContext context, DapperContext dapperContext) : base(context)
    {
        _dapperContext = dapperContext;
    }
    public async Task<InventoryResult?> GetInventoryById(Guid id)
    {
        using var connection = _dapperContext.CreateConnection();
        var sql = $"SELECT * from {_dapperContext.Inventories} where Id=@InventoryId";

        return await connection.QueryFirstOrDefaultAsync<InventoryResult>
            (sql, new { InventoryId = id });
    }
}