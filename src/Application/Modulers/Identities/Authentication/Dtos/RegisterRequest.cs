using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Enums;

namespace Alkonof_Backend.Application.Modulers.Identities.Authentication.Dtos
{
    public record RegisterRequest
    {
        public string name { get; set; } = string.Empty;
        public string number { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string confirmPassword { get; set; } = string.Empty;

    }
}
