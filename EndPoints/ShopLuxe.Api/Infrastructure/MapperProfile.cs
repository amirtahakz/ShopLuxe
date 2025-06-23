using AutoMapper;
using ShopLuxe.Api.ViewModels.Users;
using ShopLuxe.Application.Users.AddAddress;
using ShopLuxe.Application.Users.ChangePassword;

namespace ShopLuxe.Api.Infrastructure;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AddUserAddressCommand, AddUserAddressViewModel>()
            .ForMember(f => f.PhoneNumber, r => r.MapFrom(w => w.PhoneNumber)).ReverseMap();

        CreateMap<ChangePasswordViewModel, ChangeUserPasswordCommand>().ReverseMap();
    }
}