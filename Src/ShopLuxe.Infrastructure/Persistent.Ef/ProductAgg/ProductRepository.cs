using ShopLuxe.Domain.ProductAgg;
using ShopLuxe.Domain.ProductAgg.Repository;
using ShopLuxe.Infrastructure._Utilities;

namespace ShopLuxe.Infrastructure.Persistent.Ef.ProductAgg;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}