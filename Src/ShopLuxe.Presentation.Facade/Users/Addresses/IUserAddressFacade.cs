using ShopLuxe.Application.Users.AddAddress;
using ShopLuxe.Application.Users.DeleteAddress;
using ShopLuxe.Application.Users.EditAddress;
using ShopLuxe.Application.Users.SetActiveAddress;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Users.DTOs;

namespace ShopLuxe.Presentation.Facade.Users.Addresses
{
    public interface IUserAddressFacade
    {
        Task<OperationResult> AddAddress(AddUserAddressCommand command);

        Task<OperationResult> EditAddress(EditUserAddressCommand command);
        Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);

        Task<AddressDto?> GetById(Guid userAddressId);
        Task<List<AddressDto>> GetList(Guid userId);
        Task<OperationResult> SetActiveAddress(SetActiveUserAddressCommand command);
    }
}