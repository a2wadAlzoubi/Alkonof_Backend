using Alkonof_Backend.Application.Common.Interfaces;
using Application.Abstractions.JWT;
using Application.Authentication.Dtos;
using Application.Entities.Users.Services;
using Domain.RefreshTokens;

namespace Application.Authentication.SignIn
{
    public sealed record LoginCommandHandler(
        IApplicationDbContext context,
        IPasswordService passwordService,
        IJwtGenerator jwtGenerator,
        IGenerateRefreshToken generateRefreshToken
        ) : IRequestHandler<LoginCommand, RefreshTokenResponce>
    {
        public async Task<RefreshTokenResponce> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await context.User.SingleOrDefaultAsync(u=>u.Email == request.Login.Email, cancellationToken);
            Guard.Against.NotFound(request.Login.Email, user);

            if (user == null || !passwordService.Compare(request.Login.Password, user.Password))
            {
                Guard.Against.NotFound(request.Login.Email, user);
            }
            if (user.RefreshTokens == null)
                Guard.Against.NotFound(request.Login.Email, user.RefreshTokens);

            foreach (var refreshtoken in user.RefreshTokens)
            {
                if (refreshtoken.IsUsed || refreshtoken.Expired < DateTimeOffset.UtcNow)
                {
                    refreshtoken.ExpireToken();
                }
            }
            context.User.Update(user);

            var refreshToken = RefreshToken.CreateRefreshToken();
            var grefreshToken = generateRefreshToken.GRefreshToken(refreshToken, user);
            var acessToken = jwtGenerator.Generate(user, grefreshToken.Id);
            await context.RefreshToken.AddAsync(grefreshToken, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return new RefreshTokenResponce(acessToken, refreshToken);
        }
    }
}
