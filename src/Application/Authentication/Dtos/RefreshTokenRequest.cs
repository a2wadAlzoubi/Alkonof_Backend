using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication.Dtos
{
    public abstract record RefreshTokenRequest
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;

    }
}
