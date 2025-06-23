using ShopLuxe.Application.Sellers.AddInventory;
using ShopLuxe.Application.Sellers.EditInventory;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Sellers.DTOs;

namespace ShopLuxe.Presentation.Facade.Sellers.Inventories;

public interface ISellerInventoryFacade
{
    Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
    Task<OperationResult> EditInventory(EditSellerInventoryCommand command);

    Task<InventoryDto?> GetById(Guid inventoryId);
    Task<List<InventoryDto>> GetList(Guid sellerId);
    Task<List<InventoryDto>> GetByProductId(Guid productId);
}