using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.RemoveTask;

public class RemoveTaskCommandHandler : IRequestHandler<RemoveTaskCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveTaskCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.TaskTabel.FindAsync(new object[] { request.Id }, cancellationToken);

        if (task == null)
        {
            throw new NotFoundException(nameof(TaskTabel), request.Id.ToString());
        }

        _context.TaskTabel.Remove(task);

        await _context.SaveChangesAsync(cancellationToken);

    }
}
