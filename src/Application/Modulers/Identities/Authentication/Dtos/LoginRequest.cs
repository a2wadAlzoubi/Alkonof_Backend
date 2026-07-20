using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Application.Modulers.Identities.Authentication.Dtos
{
    public record LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
