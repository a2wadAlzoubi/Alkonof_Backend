using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Application.Modulers.Identities.Authentication.Dtos
{
    public abstract record RefreshTokenRequest
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;

    }
}
