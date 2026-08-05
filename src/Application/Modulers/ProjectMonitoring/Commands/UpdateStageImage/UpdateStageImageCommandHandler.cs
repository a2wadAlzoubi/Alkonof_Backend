using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.UpdateStageImage;

public class UpdateStageImageCommandHandler : IRequestHandler<UpdateStageImageCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateStageImageCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateStageImageCommand request, CancellationToken cancellationToken)
    {
        var stageImage = await _context.StageImage.FindAsync(new object[] { request.UpdateStageImageDto.Id }, cancellationToken);

        if (stageImage == null)
        {
            throw new NotFoundException(nameof(StageImage), request.UpdateStageImageDto.Id.ToString());
        }

        stageImage.UpdateStageImage(
            request.UpdateStageImageDto.FileName,
            request.UpdateStageImageDto.FilePath,
            request.UpdateStageImageDto.Description,
            request.UpdateStageImageDto.StageId
        );

        await _context.SaveChangesAsync(cancellationToken);

    }
}
