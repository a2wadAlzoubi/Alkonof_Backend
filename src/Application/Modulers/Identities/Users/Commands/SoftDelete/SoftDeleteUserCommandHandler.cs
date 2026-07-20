using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.TodoItems.Commands.DeleteTodoItem;

namespace Alkonof_Backend.Application.Modulers.Identities.Users.Commands.SoftDelete;



internal class SoftDeleteUserCommandHandler : IRequestHandler<SoftDeleteUserCommand>
{
    private readonly IApplicationDbContext _context;

    public SoftDeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.User
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, user);

        user.SoftRemoneUser(request.Id);

        await _context.SaveChangesAsync(cancellationToken);
    }

}
