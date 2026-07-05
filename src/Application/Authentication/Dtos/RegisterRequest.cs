using System;
using System.Collections.Generic;
using System.Text;
using Alkonof_Backend.Domain.Enums;

namespace Application.Authentication.Dtos
{
    public record RegisterRequest
    {
        public string Name { get; private set; } = string.Empty;
        public string Number { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string ConfirmPassword { get; set; } = null!;

    }
}
