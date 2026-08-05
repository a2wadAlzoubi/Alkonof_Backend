using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.SetStageProgress;

public class SetStageProgressCommandHandler : IRequestHandler<SetStageProgressCommand>
{
    private readonly IApplicationDbContext _context;

    public SetStageProgressCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(SetStageProgressCommand request, CancellationToken cancellationToken)
    {
        var stage = await _context.Stage.FindAsync(new object[] { request.SetStageProgressDto.Id }, cancellationToken);

        if (stage == null)
        {
            throw new NotFoundException(nameof(Stage), request.SetStageProgressDto.Id.ToString());
        }

        stage.SetProgress(request.SetStageProgressDto.Id, request.SetStageProgressDto.Progress);

        await _context.SaveChangesAsync(cancellationToken);

    }
}
