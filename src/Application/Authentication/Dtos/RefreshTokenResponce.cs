namespace Application.Authentication.Dtos
{
    public sealed record RefreshTokenResponce
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;

        public RefreshTokenResponce(string accessToken , string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
