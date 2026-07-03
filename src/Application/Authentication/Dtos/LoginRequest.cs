using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication.Dtos
{
    public record LoginRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; } = false;
    }
}
