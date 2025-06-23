using ShopLuxe.Application.Products.AddImage;
using ShopLuxe.Application.Products.Create;
using ShopLuxe.Application.Products.Edit;
using ShopLuxe.Application.Products.RemoveImage;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Products.DTOs;
using ShopLuxe.Query.Sellers.DTOs;

namespace ShopLuxe.Presentation.Facade.Products;

public interface IProductFacade
{
    Task<OperationResult> CreateProduct(CreateProductCommand command);
    Task<OperationResult> EditProduct(EditProductCommand command);
    Task<OperationResult> AddImage(AddProductImageCommand command);
    Task<OperationResult> RemoveImage(RemoveProductImageCommand command);

    Task<ProductDto?> GetProductById(Guid productId);
    Task<ProductDto?> GetProductBySlug(string slug);
    Task<SingleProductDto?> GetProductBySlugForSinglePage(string slug);
    Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams);
    Task<ProductShopResult> GetProductsForShop(ProductShopFilterParam filterParams);
}

public class SingleProductDto
{
    public ProductDto ProductDto { get; set; }
    public List<InventoryDto> Inventories { get; set; }
}