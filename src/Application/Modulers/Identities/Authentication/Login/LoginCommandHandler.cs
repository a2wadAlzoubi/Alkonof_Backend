using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Common.Models;
using Alkonof_Backend.Application.Modulers.Identities.Authentication.Dtos;
using Application.Abstractions.JWT;
using Domain.RefreshTokens;

namespace Alkonof_Backend.Application.Modulers.Identities.Authentication.Login
{
    public sealed class LoginCommandHandler(
        IApplicationDbContext context,
        IPasswordService passwordService,
        IJwtGenerator jwtGenerator,
        IGenerateRefreshToken generateRefreshToken)
        : IRequestHandler<LoginCommand, RefreshTokenResponce>
    {
        public async Task<RefreshTokenResponce> Handle(
            LoginCommand request,
            CancellationToken cancellationToken)
        {
            // 1- Load User + RefreshTokens
            var user = await context.User
                .Include(u => u.RefreshTokens)
                .SingleOrDefaultAsync(
                    u => u.Email == request.Login.Email && u.IsDeleted != true,
                    cancellationToken);


            // 2- Validate User
            if (user is null || user.RefreshTokens is null)
            {
                throw new UnauthorizedAccessException(
                    "Invalid email or password");
            }


            // 3- Validate Password
            var isPasswordValid =
                passwordService.Compare(
                    request.Login.Password,
                    user.Password);


            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException(
                    "Invalid email or password");
            }


             //4 - Expire old refresh tokens
            //foreach (var token in user.RefreshTokens)
            //{
            //    if (token.IsUsed ||
            //        token.Expired <= DateTimeOffset.UtcNow)
            //    {
            //        token.ExpireToken();
            //        context.RefreshToken.Remove(token);
            //    }
            //}


            // 5- Create new Refresh Token
            var refreshToken =
                RefreshToken.CreateRefreshToken();


            // 6- Create persistence RefreshToken
            var refreshTokenEntity =
                generateRefreshToken.GRefreshToken(
                    refreshToken,
                    user);


            // 7- Generate Access Token
            var accessToken =
                jwtGenerator.Generate(
                    user,
                    refreshTokenEntity.Id);


            // 8- Add only RefreshToken
            await context.RefreshToken.AddAsync(
                refreshTokenEntity,
                cancellationToken);


            // 9- Save
            await context.SaveChangesAsync(
                cancellationToken);


            return new RefreshTokenResponce(
                accessToken,
                refreshToken);
        }
    }
}
