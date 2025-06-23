using ShopLuxe.Application.Sellers.Create;
using ShopLuxe.Application.Sellers.Edit;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Sellers.DTOs;

namespace ShopLuxe.Presentation.Facade.Sellers;

public interface ISellerFacade
{
    Task<OperationResult> CreateSeller(CreateSellerCommand command);
    Task<OperationResult> EditSeller(EditSellerCommand command);

    Task<SellerDto?> GetSellerById(Guid sellerId);
    Task<SellerDto?> GetSellerByUserId(Guid userId);
    Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams);
}