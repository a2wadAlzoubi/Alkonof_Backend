//using Application.Abstractions;
//using Application.Abstractions.JWT;
//using Application.Abstractions.Messaging;
//using Application.Authentication.Dtos;
//using Application.Entities.Users.Services;
//using Application.Entities.Users.Specifications;
//using Domain.Abstractions;
//using Domain.RefreshTokens;
//using FainancialGuard.Domain.Entities.Users;

//namespace Application.Authentication.Register
//{
//    internal sealed record RegisterCommandHandler(
//        IRepository<User> Repository,
//        IRepository<RefreshToken> rtRepository,
//        IPasswordService passwordService,
//        IJwtGenerator jwtGenerator,
//        IGenerateRefreshToken GenerateRefreshToken,
//        IUnitOfWork unitOfWork
//        ) : ICommandHandler<RegisterCommand, RefreshTokenResponce>
//    {
//        public async Task<Result<RefreshTokenResponce>> Handle(RegisterCommand request, CancellationToken cancellationToken)
//        {
//            var exsitedUsers = await Repository.GetAllWithRelated(new GetUserByEmail(request.Register.Email), cancellationToken);

//            if ((exsitedUsers != null && exsitedUsers.Count() > 0) || string.IsNullOrEmpty(request.Register.Email))
//            {
//                return Result.Failure<RefreshTokenResponce>(ErrorType.EmailExists);
//            }
//            if(request.Register.Password != request.Register.ConfirmPassword)
//            {
//                return Result.Failure<RefreshTokenResponce>(ErrorType.IncorrectCredentials);
//            }
//            var hashPassword = passwordService.Hash(request.Register.Password);
//            User user = User.Create(request.Register.FullName, request.Register.Email, hashPassword , Role.member);

//            var refreshToken = RefreshToken.CreateRefreshToken();
//            var grefreshToken = GenerateRefreshToken.GRefreshToken(refreshToken, user);
//            var acessToken = jwtGenerator.Generate(user, grefreshToken.Id);
//            await rtRepository.Add(grefreshToken, cancellationToken);
//            await Repository.Add(user,cancellationToken);

//            await unitOfWork.SaveChangesAsync();

//            return new RefreshTokenResponce(acessToken , refreshToken);
//        }
//    }
//}
