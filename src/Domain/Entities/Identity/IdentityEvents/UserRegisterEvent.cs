using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Identity.IdentityEvents;

public class UserRegisterEvent : BaseEvent
{
    public UserRegisterEvent(Guid UserId, string Email)
    {
        this.UserId = UserId;
        this.Email = Email;
    }
    public Guid UserId { get; }
    public string Email { get; }
}
