using ShopLuxe.Common.Query;
using ShopLuxe.Query.Users.DTOs;

namespace ShopLuxe.Query.Users.Addresses.GetList;

public record GetUserAddressesListQuery(Guid UserId) : IQuery<List<AddressDto>>;