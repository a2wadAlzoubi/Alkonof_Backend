using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.RemoveStageImage;

public class RemoveStageImageCommandHandler : IRequestHandler<RemoveStageImageCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveStageImageCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveStageImageCommand request, CancellationToken cancellationToken)
    {
        var stageImage = await _context.StageImage.FindAsync(new object[] { request.Id }, cancellationToken);

        if (stageImage == null)
        {
            throw new NotFoundException(nameof(StageImage), request.Id.ToString());
        }

        _context.StageImage.Remove(stageImage);

        await _context.SaveChangesAsync(cancellationToken);

    }
}
