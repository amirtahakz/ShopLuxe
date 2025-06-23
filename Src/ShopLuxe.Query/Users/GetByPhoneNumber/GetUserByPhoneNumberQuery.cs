using ShopLuxe.Common.Query;
using ShopLuxe.Query.Users.DTOs;

namespace ShopLuxe.Query.Users.GetByPhoneNumber;

public record GetUserByPhoneNumberQuery(string PhoneNumber) : IQuery<UserDto?>;