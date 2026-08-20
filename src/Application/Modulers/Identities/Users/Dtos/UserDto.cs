﻿using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Dtos;

public class UserDto
{
    public UserDto(Guid id, string name, string number, string email, UserRole role, bool isDeleted, Guid? permissionId , Specialization? specialization)
    {
        Id = id;
        Name = name;
        Number = number;
        Email = email;
        Role = role;
        IsDeleted = isDeleted;
        PermissionId = permissionId;
        Specialization = specialization;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.Customer;
    public bool IsDeleted { get; set; } = false;
    public Guid? PermissionId { get; set; }
    public Specialization? Specialization { get; set; } = Domain.Entities.Identity.Enum.Specialization.None;

}
