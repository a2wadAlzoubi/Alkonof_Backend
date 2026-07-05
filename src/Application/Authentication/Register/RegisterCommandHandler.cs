using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities;
using Application.Abstractions.JWT;
using Application.Authentication.Dtos;
using Application.Entities.Users.Services;
using Domain.RefreshTokens;

namespace Application.Authentication.Register
{
    internal sealed record RegisterCommandHandler(
        IApplicationDbContext context ,
        IPasswordService passwordService,
        IJwtGenerator jwtGenerator,
        IGenerateRefreshToken GenerateRefreshToken
        ) : IRequestHandler<RegisterCommand, RefreshTokenResponce>
    {
        public async Task<RefreshTokenResponce> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var exsitedUser = await context.User.FindAsync(request.Register.Email);

            if ((exsitedUser != null) || string.IsNullOrEmpty(request.Register.Email))
                Guard.Against.NotFound(request.Register.Email, exsitedUser);
            if (request.Register.Password != request.Register.ConfirmPassword)
                Guard.Against.NotFound(request.Register.Email, exsitedUser);

            var hashPassword = passwordService.Hash(request.Register.Password);
            User user = User.Register(request.Register.Name,request.Register.Number, request.Register.Email, hashPassword);

            var refreshToken = RefreshToken.CreateRefreshToken();
            var grefreshToken = GenerateRefreshToken.GRefreshToken(refreshToken, user);
            var acessToken = jwtGenerator.Generate(user, grefreshToken.Id);
            await context.RefreshToken.AddAsync(grefreshToken, cancellationToken);
            await context.User.AddAsync(user, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            return new RefreshTokenResponce(acessToken, refreshToken);
        }
    }
}
