using MediatR;
using ShopLuxe.Query.Users.Addresses.GetById;
using ShopLuxe.Query.Users.Addresses.GetList;
using ShopLuxe.Application.Users.AddAddress;
using ShopLuxe.Application.Users.DeleteAddress;
using ShopLuxe.Application.Users.EditAddress;
using ShopLuxe.Application.Users.SetActiveAddress;
using ShopLuxe.Common.Application;
using ShopLuxe.Query.Users.DTOs;

namespace ShopLuxe.Presentation.Facade.Users.Addresses
{
    internal class UserAddressFacade : IUserAddressFacade
    {
        private readonly IMediator _mediator;

        public UserAddressFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddAddress(AddUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditAddress(EditUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command)
        {
            return await _mediator.Send(command);

        }

        public async Task<AddressDto?> GetById(Guid userAddressId)
        {
            return await _mediator.Send(new GetUserAddressByIdQuery(userAddressId));

        }

        public async Task<List<AddressDto>> GetList(Guid userId)
        {
            return await _mediator.Send(new GetUserAddressesListQuery(userId));
        }

        public async Task<OperationResult> SetActiveAddress(SetActiveUserAddressCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}