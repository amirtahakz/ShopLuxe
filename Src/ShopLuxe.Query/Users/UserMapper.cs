﻿using Microsoft.EntityFrameworkCore;
using ShopLuxe.Domain.UserAgg;
using ShopLuxe.Infrastructure.Persistent.Ef;
using ShopLuxe.Query.Users.DTOs;

namespace ShopLuxe.Query.Users;

public static class UserMapper
{
    public static UserDto Map(this User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            CreationDate = user.CreationDate,
            Family = user.Family,
            PhoneNumber = user.PhoneNumber,
            AvatarName = user.AvatarName,
            Email = user.Email,
            Gender = user.Gender,
            Name = user.Name,
            Password = user.Password,
            IsActive = user.IsActive,
            Roles = user.Roles.Select(s => new UserRoleDto()
            {
                RoleId = s.RoleId,
                RoleTitle = ""
            }).ToList()
        };
    }

    public static async Task<UserDto> SetUserRoleTitles(this UserDto userDto, ApplicationDbContext context)
    {
        var roleIds = userDto.Roles.Select(r => r.RoleId);
        var result = await context.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();
        var roles = new List<UserRoleDto>();
        foreach (var role in result)
        {
            roles.Add(new UserRoleDto()
            {
                RoleId = role.Id,
                RoleTitle = role.Title
            });
        }

        userDto.Roles = roles;
        return userDto;
    }
    public static UserFilterData MapFilterData(this User user)
    {
        return new UserFilterData()
        {
            Id = user.Id,
            CreationDate = user.CreationDate,
            Family = user.Family,
            PhoneNumber = user.PhoneNumber,
            AvatarName = user.AvatarName,
            Email = user.Email,
            Gender = user.Gender,
            Name = user.Name
        };
    }
}