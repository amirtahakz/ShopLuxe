using ShopLuxe.Api.Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopLuxe.Application.Sellers.AddInventory;
using ShopLuxe.Application.Sellers.Create;
using ShopLuxe.Application.Sellers.Edit;
using ShopLuxe.Application.Sellers.EditInventory;
using ShopLuxe.Common.AspNetCore;
using ShopLuxe.Domain.RoleAgg.Enums;
using ShopLuxe.Presentation.Facade.Sellers;
using ShopLuxe.Presentation.Facade.Sellers.Inventories;
using ShopLuxe.Query.Sellers.DTOs;

namespace ShopLuxe.Api.Controllers;


public class SellerController : ApiController
{
    private readonly ISellerFacade _sellerFacade;
    private readonly ISellerInventoryFacade _sellerInventoryFacade;
    public SellerController(ISellerFacade sellerFacade, ISellerInventoryFacade sellerInventoryFacade)
    {
        _sellerFacade = sellerFacade;
        _sellerInventoryFacade = sellerInventoryFacade;
    }

    [HttpGet]
    [PermissionChecker(Permission.Seller_Management)]
    public async Task<ApiResult<SellerFilterResult>> GetSellers(SellerFilterParams filterParams)
    {
        var result = await _sellerFacade.GetSellersByFilter(filterParams);
        return QueryResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<SellerDto?>> GetSellerById(Guid sellerId)
    {
        var result = await _sellerFacade.GetSellerById(sellerId);
        return QueryResult(result);
    }

    [Authorize]
    [HttpGet("current")]
    public async Task<ApiResult<SellerDto?>> GetSeller()
    {
        var result = await _sellerFacade.GetSellerByUserId(User.GetUserId());
        return QueryResult(result);
    }

    [HttpPost]
    [PermissionChecker(Permission.Seller_Management)]
    public async Task<ApiResult> CreateSeller(CreateSellerCommand command)
    {
        var result = await _sellerFacade.CreateSeller(command);
        return CommandResult(result);
    }

    [HttpPut]
    [PermissionChecker(Permission.Seller_Management)]

    public async Task<ApiResult> EditSeller(EditSellerCommand command)
    {
        var result = await _sellerFacade.EditSeller(command);
        return CommandResult(result);
    }

    [HttpPost("Inventory")]
    [PermissionChecker(Permission.Add_Inventory)]
    public async Task<ApiResult> AddInventory(AddSellerInventoryCommand command)
    {
        var result = await _sellerInventoryFacade.AddInventory(command);
        return CommandResult(result);
    }
    [HttpPut("Inventory")]
    [PermissionChecker(Permission.Edit_Inventory)]
    public async Task<ApiResult> EditInventory(EditSellerInventoryCommand command)
    {
        var result = await _sellerInventoryFacade.EditInventory(command);
        return CommandResult(result);
    }

    [HttpGet("Inventory")]
    [PermissionChecker(Permission.Seller_Panel)]
    public async Task<ApiResult<List<InventoryDto>>> GetInventories()
    {
        var seller = await _sellerFacade.GetSellerByUserId(User.GetUserId());
        if (seller == null)
            return QueryResult(new List<InventoryDto>());

        var result = await _sellerInventoryFacade.GetList(seller.Id);
        return QueryResult(result);
    }
    [HttpGet("Inventory/{inventoryId}")]
    public async Task<ApiResult<InventoryDto>> GetInventoryById(Guid inventoryId)
    {
        var result = await _sellerInventoryFacade.GetById(inventoryId);
        if (result == null)
            return QueryResult(new InventoryDto());
        return QueryResult(result);
    }

}