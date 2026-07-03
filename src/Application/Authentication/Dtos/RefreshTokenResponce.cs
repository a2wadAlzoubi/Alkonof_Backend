namespace Application.Authentication.Dtos
{
    public sealed record RefreshTokenResponce
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;

        public RefreshTokenResponce(string accessToken , string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
