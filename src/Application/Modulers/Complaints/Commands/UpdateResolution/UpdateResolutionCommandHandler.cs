using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.UpdateResolution;

public sealed class UpdateResolutionCommandHandler : IRequestHandler<UpdateResolutionCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateResolutionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateResolutionCommand request, CancellationToken cancellationToken)
    {
        var resolution = await _context.Resolution.FindAsync(new object[] { request.Dto.Id }, cancellationToken);
        
        if (resolution == null)
        {
            throw new NotFoundException("Resolution not found" , nameof(resolution));
        }

        resolution.Update(
            request.Dto.ComplintId,
            request.Dto.ResolutionText
        );

        await _context.SaveChangesAsync(cancellationToken);
    }
}
