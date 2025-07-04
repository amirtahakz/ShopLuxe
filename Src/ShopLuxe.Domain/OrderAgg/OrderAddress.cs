﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopLuxe.Common.Domain.ValueObjects;
using ShopLuxe.Common.Domain;

namespace ShopLuxe.Domain.OrderAgg
{
    public class OrderAddress : BaseEntity
    {
        private OrderAddress()
        {

        }
        public OrderAddress(string shire, string city, string postalCode, string postalAddress,
            string phoneNumber, string name, string family, string nationalCode)
        {
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }

        public Guid OrderId { get; internal set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string NationalCode { get; private set; }
        //public Order Order { get; set; }
    }
}
