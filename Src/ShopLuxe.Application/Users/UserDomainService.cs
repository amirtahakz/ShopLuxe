﻿using ShopLuxe.Domain.UserAgg.Repository;
using ShopLuxe.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLuxe.Application.Users
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _repository;

        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool IsEmailExist(string email)
        {
            return _repository.Exists(r => r.Email == email);
        }

        public bool IsPhoneNumberExist(string phoneNumber)
        {
            return _repository.Exists(r => r.PhoneNumber == phoneNumber);

        }
    }
}
