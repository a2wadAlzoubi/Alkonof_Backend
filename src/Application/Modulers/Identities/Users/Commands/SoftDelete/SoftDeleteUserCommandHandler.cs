using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.TodoItems.Commands.DeleteTodoItem;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.SoftDelete;

internal class SoftDeleteUserCommandHandler : IRequestHandler<SoftActiveDeleteUserCommand>
{
    private readonly IApplicationDbContext _context;

    public SoftDeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(SoftActiveDeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.User
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, user);

        if(user.Role == UserRole.Admin)
        {
            throw new Exception("Admin user cannot be deleted.");
        }

        user.SoftActiveRemoveUser(request.IsDeleted);

        await _context.SaveChangesAsync(cancellationToken);
    }

}
