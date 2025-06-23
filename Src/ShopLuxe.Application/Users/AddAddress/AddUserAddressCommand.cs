using ShopLuxe.Common.Application;
using ShopLuxe.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Users.AddAddress
{
    public class AddUserAddressCommand : IBaseCommand
    {
        public AddUserAddressCommand(Guid userId, string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber, string nationalCode, string name , string family)
        {
            UserId = userId;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            Name = name;
            Family = family;
        }
        public Guid UserId { get; set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }

    }
}
