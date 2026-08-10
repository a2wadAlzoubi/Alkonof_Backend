using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Application.Abstractions
{
    public interface ICurrentUserProvider
    {
        public Guid Id { get;}
        public UserRole Role { get; }
    }
}
