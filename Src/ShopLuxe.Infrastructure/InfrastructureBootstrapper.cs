using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopLuxe.Domain.CategoryAgg.Repository;
using ShopLuxe.Domain.CommentAgg.Repository;
using ShopLuxe.Domain.FavoriteAgg.Repository;
using ShopLuxe.Domain.OrderAgg.Repository;
using ShopLuxe.Domain.ProductAgg.Repository;
using ShopLuxe.Domain.RoleAgg.Repository;
using ShopLuxe.Domain.SellerAgg.Repository;
using ShopLuxe.Domain.SiteEntities.Repositories;
using ShopLuxe.Domain.UserAgg.Repository;
using ShopLuxe.Infrastructure._Utilities.MediatR;
using ShopLuxe.Infrastructure.Persistent.Dapper;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Infrastructure.Persistent.Ef.CategoryAgg;
using ShopLuxe.Infrastructure.Persistent.Ef.CommentAgg;
using ShopLuxe.Infrastructure.Persistent.Ef.FavoriteAgg;
using ShopLuxe.Infrastructure.Persistent.Ef.OrderAgg;
using ShopLuxe.Infrastructure.Persistent.Ef.ProductAgg;
using ShopLuxe.Infrastructure.Persistent.Ef.RoleAgg;
using ShopLuxe.Infrastructure.Persistent.Ef.SellerAgg;
using ShopLuxe.Infrastructure.Persistent.Ef.SiteEntities.Repositories;
using ShopLuxe.Infrastructure.Persistent.Ef.UserAgg;
namespace ShopLuxe.Infrastructure;

public class InfrastructureBootstrapper
{
    public static void Init(IServiceCollection services, string connectionString)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<ISellerRepository, SellerRepository>();
        services.AddTransient<IBannerRepository, BannerRepository>();
        services.AddTransient<ISliderRepository, SliderRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<IShippingMethodRepository, ShippingMethodRepository>();
        services.AddTransient<IFavoriteRepository, FavoriteRepository>();

        services.AddSingleton<ICustomPublisher, CustomPublisher>();

        services.AddTransient(_ => new DapperContext(connectionString));

        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(connectionString);
        });
    }
}