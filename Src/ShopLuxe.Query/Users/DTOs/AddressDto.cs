﻿using ShopLuxe.Common.Domain.ValueObjects;
using ShopLuxe.Common.Query;

namespace ShopLuxe.Query.Users.DTOs;

public class AddressDto : BaseDto
{
    public Guid UserId { get; set; }
    public string Shire { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string PostalAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string NationalCode { get; set; }
    public bool ActiveAddress { get; set; }
}