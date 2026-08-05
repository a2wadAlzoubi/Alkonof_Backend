using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateTaskCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = TaskTabel.CreateTask(
            request.CreateTaskDto.Title,
            request.CreateTaskDto.Description,
            request.CreateTaskDto.StartedDate,
            request.CreateTaskDto.ActualEndedDate,
            request.CreateTaskDto.Progress,
            request.CreateTaskDto.StageId,
            request.CreateTaskDto.Priority
        );

        _context.TaskTabel.Add(task);

        await _context.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}
