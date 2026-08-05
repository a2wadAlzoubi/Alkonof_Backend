using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.RemoveStage;

public class RemoveStageCommandHandler : IRequestHandler<RemoveStageCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveStageCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveStageCommand request, CancellationToken cancellationToken)
    {
        var stage = await _context.Stage.FindAsync(new object[] { request.Id }, cancellationToken);

        if (stage == null)
        {
            throw new NotFoundException(nameof(Stage), request.Id.ToString());
        }

        _context.Stage.Remove(stage);

        await _context.SaveChangesAsync(cancellationToken);

    }
}
