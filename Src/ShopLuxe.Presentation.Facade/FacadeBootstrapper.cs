using Microsoft.Extensions.DependencyInjection;
using ShopLuxe.Presentation.Facade.SiteEntities.ShippingMethods;
using ShopLuxe.Presentation.Facade.Comments;
using ShopLuxe.Presentation.Facade.Orders;
using ShopLuxe.Presentation.Facade.SiteEntities.Slider;
using ShopLuxe.Presentation.Facade.Categories;
using ShopLuxe.Presentation.Facade.Favorite;
using ShopLuxe.Presentation.Facade.Sellers;
using ShopLuxe.Presentation.Facade.SiteEntities.Banner;
using ShopLuxe.Presentation.Facade.Users;
using ShopLuxe.Presentation.Facade.Roles;
using ShopLuxe.Presentation.Facade.Products;
using ShopLuxe.Presentation.Facade.Sellers.Inventories;
using ShopLuxe.Presentation.Facade.Users.Addresses;

namespace ShopLuxe.Presentation.Facade;

public static class FacadeBootstrapper
{
    public static void InitFacadeDependency(this IServiceCollection services)
    {
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        services.AddScoped<IFavoriteFacade, FavoriteFacade>();
        services.AddScoped<ICommentFacade, CommentFacade>();
        services.AddScoped<IOrderFacade, OrderFacade>();
        services.AddScoped<IProductFacade, ProductFacade>();
        services.AddScoped<IRoleFacade, RoleFacade>();
        services.AddScoped<ISellerFacade, SellerFacade>();
        services.AddScoped<IBannerFacade, BannerFacade>();
        services.AddScoped<ISliderFacade, SliderFacade>();
        services.AddScoped<ISellerInventoryFacade, SellerInventoryFacade>();
        services.AddScoped<IShippingMethodFacade, ShippingMethodFacade>();

        services.AddScoped<IUserFacade, UserFacade>();
        services.AddScoped<IUserAddressFacade, UserAddressFacade>();

    }
}