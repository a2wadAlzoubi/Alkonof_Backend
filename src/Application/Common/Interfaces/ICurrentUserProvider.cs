using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Common.Interfaces
{
    public interface ICurrentUserProvider
    {
        public Guid Id { get;}
        public UserRole Role { get; }
    }
}
