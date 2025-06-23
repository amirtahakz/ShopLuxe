using ShopLuxe.Application.Users.AddAddress;
using ShopLuxe.Application.Users.DeleteAddress;
using ShopLuxe.Application.Users.EditAddress;
using ShopLuxe.Application.Users.SetActiveAddress;
using AutoMapper;
using ShopLuxe.Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopLuxe.Api.ViewModels.Users;
using ShopLuxe.Common.AspNetCore;
using ShopLuxe.Presentation.Facade.Users.Addresses;
using ShopLuxe.Query.Users.DTOs;

namespace ShopLuxe.Api.Controllers;

[Authorize]
public class UserAddressController : ApiController
{
    private readonly IUserAddressFacade _userAddress;
    private readonly IMapper _mapper;
    public UserAddressController(IUserAddressFacade userAddress, IMapper mapper)
    {
        _userAddress = userAddress;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ApiResult<List<AddressDto>>> GetList()
    {
        var result = await _userAddress.GetList(User.GetUserId());
        return QueryResult(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<AddressDto?>> GetById(Guid id)
    {
        var result = await _userAddress.GetById(id);
        return QueryResult(result);
    }
    [HttpPost]
    public async Task<ApiResult> AddAddress(AddUserAddressViewModel viewModel)
    {
        var command = new AddUserAddressCommand(User.GetUserId(), viewModel.Shire, viewModel.City, viewModel.PostalCode,
            viewModel.PostalAddress, new PhoneNumber(viewModel.PhoneNumber), viewModel.NationalCode ,viewModel.Name , viewModel.Family);

        var result = await _userAddress.AddAddress(command);
        return CommandResult(result);
    }

    [HttpDelete("{addressId}")]
    public async Task<ApiResult> Delete(Guid addressId)
    {
        var result = await _userAddress.DeleteAddress(new DeleteUserAddressCommand(User.GetUserId(), addressId));
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> Edit(EditUserAddressViewModel viewModel)
    {
        var command = new EditUserAddressCommand(viewModel.Shire, viewModel.City, viewModel.PostalCode,
            viewModel.PostalAddress, new PhoneNumber(viewModel.PhoneNumber), viewModel.Name , viewModel.Family, viewModel.NationalCode, User.GetUserId() , viewModel.Id);

        //command.UserId = User.GetUserId();
        var result = await _userAddress.EditAddress(command);
        return CommandResult(result);
    }
    [HttpPut("SetActiveAddress/{addressId}")]
    public async Task<ApiResult> SetAddressActive(Guid addressId)
    {
        var command = new SetActiveUserAddressCommand(User.GetUserId(), addressId);

        var result = await _userAddress.SetActiveAddress(command);
        return CommandResult(result);
    }
}