using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Identities.Authentication.Dtos;
using Alkonof_Backend.Application.Modulers.Identities.Users.Services;
using Alkonof_Backend.Domain.Entities.Identity;
using Application.Abstractions.JWT;
using Domain.RefreshTokens;

namespace Alkonof_Backend.Application.Modulers.Identities.Authentication.Register
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
            var email = request.Register.email;
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.", nameof(request.Register.email));

            var exsitedUser = await context.User.SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
            if (exsitedUser != null)
                throw new InvalidOperationException("A user with this email already exists.");
            if (request.Register.password != request.Register.confirmPassword)
                throw new ArgumentException("Password and confirmation do not match.", nameof(request.Register.confirmPassword));

            var hashPassword = passwordService.Hash(request.Register.password);
            User user = User.Register(request.Register.name,request.Register.number, email, hashPassword );
            //User user = User.Register(request.Register.name, request.Register.number, email, hashPassword);

            var refreshToken = RefreshToken.CreateRefreshToken();
            var grefreshToken = GenerateRefreshToken.GRefreshToken(refreshToken, user);
            var acessToken = jwtGenerator.Generate(user, grefreshToken.Id);
            var before = context.User.Count();
             context.User.Add(user);
             context.RefreshToken.Add(grefreshToken);

            await context.SaveChangesAsync(cancellationToken);
            var after = context.User.Count();
            var after2 = context.RefreshToken.Count();

            return new RefreshTokenResponce(acessToken, refreshToken);
        }
    }
}
