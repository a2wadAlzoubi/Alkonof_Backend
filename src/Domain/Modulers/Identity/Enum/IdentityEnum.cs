using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Identity.Enum;


public enum UserRole
{
    admin = 0,
    responsible = 1,
    customer = 2,
}
public enum UserStatus
{
    active = 0,
    suspended = 1,
    locked = 2,
    deleted = 3,
    unActive = 4,
}
