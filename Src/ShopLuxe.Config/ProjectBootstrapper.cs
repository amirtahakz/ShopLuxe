using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShopLuxe.Application._Utilities;
using ShopLuxe.Application.Categories;
using ShopLuxe.Application.Products;
using ShopLuxe.Application.Roles.Create;
using ShopLuxe.Application.Sellers;
using ShopLuxe.Application.Users;
using ShopLuxe.Domain.CategoryAgg.Services;
using ShopLuxe.Domain.ProductAgg.Services;
using ShopLuxe.Domain.SellerAgg.Services;
using ShopLuxe.Domain.UserAgg.Services;
using ShopLuxe.Infrastructure;
using ShopLuxe.Presentation.Facade;
using ShopLuxe.Query.Categories.GetById;

namespace ShopLuxe.Config
{
    public static class ProjectBootstrapper
    {
        public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
        {
            InfrastructureBootstrapper.Init(services, connectionString);

            services.AddMediatR(typeof(Directories).Assembly);

            services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);

            services.AddTransient<IProductDomainService, ProductDomainService>();
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            services.AddTransient<ISellerDomainService, SellerDomainService>();


            services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);

            services.InitFacadeDependency();
        }
    }
}