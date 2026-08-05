using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.ChangeStageStatus;

public class ChangeStageStatusCommandHandler : IRequestHandler<ChangeStageStatusCommand>
{
    private readonly IApplicationDbContext _context;

    public ChangeStageStatusCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(ChangeStageStatusCommand request, CancellationToken cancellationToken)
    {
        var stage = await _context.Stage.FindAsync(new object[] { request.ChangeStageStatusDto.Id }, cancellationToken);

        if (stage == null)
        {
            throw new NotFoundException(nameof(Stage), request.ChangeStageStatusDto.Id.ToString());
        }

        stage.ChangeStageStatus(request.ChangeStageStatusDto.Id, request.ChangeStageStatusDto.Status);

        await _context.SaveChangesAsync(cancellationToken);

    }
}
