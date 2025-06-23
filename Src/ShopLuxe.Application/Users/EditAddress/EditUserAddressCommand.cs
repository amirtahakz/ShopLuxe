using ShopLuxe.Common.Application;
using ShopLuxe.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Users.EditAddress
{
    public class EditUserAddressCommand : IBaseCommand
    {
        public EditUserAddressCommand(string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber, string name, string family,
            string nationalCode, Guid userId, Guid id)
        {
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            UserId = userId;
            Id = id;
        }

        public Guid UserId { get; set; }
        public Guid Id { get; private set; }
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
