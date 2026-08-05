using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateStage;

public class UpdateStageCommandHandler : IRequestHandler<UpdateStageCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateStageCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateStageCommand request, CancellationToken cancellationToken)
    {
        var stage = await _context.Stage.FindAsync(new object[] { request.UpdateStageDto.Id }, cancellationToken);

        if (stage == null)
        {
            throw new NotFoundException(nameof(Stage), request.UpdateStageDto.Id.ToString());
        }

        stage.UpdateStage(
            request.UpdateStageDto.Name,
            request.UpdateStageDto.Description,
            request.UpdateStageDto.Progress,
            request.UpdateStageDto.StartedDate,
            request.UpdateStageDto.ActualEndedDate,
            request.UpdateStageDto.ProjectId,
            request.UpdateStageDto.Status
        );

        await _context.SaveChangesAsync(cancellationToken);

    }
}
