using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities;

namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.Create;

internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(
        request.CreateUser.Name,
        request.CreateUser.Number,
        request.CreateUser.Email,
        request.CreateUser.Password,
        request.CreateUser.Status,
        request.CreateUser.Role
            );

        _context.User.Add(user);

        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
