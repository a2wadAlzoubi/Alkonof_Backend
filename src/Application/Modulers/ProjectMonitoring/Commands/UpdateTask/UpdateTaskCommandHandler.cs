using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateTask;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTaskCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.TaskTabel.FindAsync(new object[] { request.UpdateTaskDto.Id }, cancellationToken);

        if (task == null)
        {
            throw new NotFoundException(nameof(TaskTabel), request.UpdateTaskDto.Id.ToString());
        }

        task.UpdateTask(
            request.UpdateTaskDto.Title,
            request.UpdateTaskDto.Description,
            request.UpdateTaskDto.Priority,
            request.UpdateTaskDto.StartedDate,
            request.UpdateTaskDto.ActualEndedDate,
            request.UpdateTaskDto.Progress,
            request.UpdateTaskDto.StageId
        );

        await _context.SaveChangesAsync(cancellationToken);

    }
}
