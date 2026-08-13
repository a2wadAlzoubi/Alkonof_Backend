using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.TodoItems.Commands.DeleteTodoItem;
using Alkonof_Backend.Domain.Entities.Identity.Enum;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.Delete;



internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserProvider _currentUserProvider;

    public DeleteUserCommandHandler(IApplicationDbContext context , ICurrentUserProvider currentUserProvider)
    {
        _context = context;
        _currentUserProvider = currentUserProvider;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {

        //if (_currentUserProvider.Role != UserRole.Admin) { throw new InvalidOperationException("Current user is not authenticated."); }
        
        var user = await _context.User
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, user);
        if(user.Role == UserRole.Admin)
        {
            throw new InvalidOperationException("Cannot delete an admin user.");
        }
        _context.User.Remove(user);

        await _context.SaveChangesAsync(cancellationToken);
    }

}
