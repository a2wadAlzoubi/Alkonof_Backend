using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.TodoItems.Commands.DeleteTodoItem;

namespace Alkonof_Backend.Application.Users.ToDoUser.Commands.Delete;



internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.User
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, user);

        _context.User.Remove(user);

        await _context.SaveChangesAsync(cancellationToken);
    }

}
