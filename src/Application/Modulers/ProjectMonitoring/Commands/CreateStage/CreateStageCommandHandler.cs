using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateStage;

public class CreateStageCommandHandler : IRequestHandler<CreateStageCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateStageCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateStageCommand request, CancellationToken cancellationToken)
    {
        var stage = Stage.CreateStage(
            request.CreateStageDto.Name,
            request.CreateStageDto.Description,
            request.CreateStageDto.Progress,
            request.CreateStageDto.StartedDate,
            request.CreateStageDto.ActualEndedDate,
            request.CreateStageDto.ProjectId,
            request.CreateStageDto.Status
        );

        _context.Stage.Add(stage);

        await _context.SaveChangesAsync(cancellationToken);

        return stage.Id;
    }
}
