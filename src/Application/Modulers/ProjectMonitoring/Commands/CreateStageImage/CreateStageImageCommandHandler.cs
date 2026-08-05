using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Commands.CreateStageImage;

public class CreateStageImageCommandHandler : IRequestHandler<CreateStageImageCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateStageImageCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateStageImageCommand request, CancellationToken cancellationToken)
    {
        var stageImage = StageImage.CreateStageImage(
            request.CreateStageImageDto.FileName,
            request.CreateStageImageDto.FilePath,
            request.CreateStageImageDto.Description,
            request.CreateStageImageDto.StageId
        );

        _context.StageImage.Add(stageImage);

        await _context.SaveChangesAsync(cancellationToken);

        return stageImage.Id;
    }
}
