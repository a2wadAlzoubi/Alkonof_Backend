using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.ChangePriorityTask;

public class ChangePriorityTaskCommandHandler : IRequestHandler<ChangePriorityTaskCommand>
{
    private readonly IApplicationDbContext _context;

    public ChangePriorityTaskCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(ChangePriorityTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.TaskTabel.FindAsync(new object[] { request.ChangePriorityTaskDto.Id }, cancellationToken);

        if (task == null)
        {
            throw new NotFoundException(nameof(TaskTabel), request.ChangePriorityTaskDto.Id.ToString());
        }

        task.ChangePriorityTask(request.ChangePriorityTaskDto.Id, request.ChangePriorityTaskDto.Priority);

        await _context.SaveChangesAsync(cancellationToken);

    }
}
