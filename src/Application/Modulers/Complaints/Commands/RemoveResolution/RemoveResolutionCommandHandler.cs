using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities.Complains;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.RemoveResolution;

public sealed class RemoveResolutionCommandHandler : IRequestHandler<RemoveResolutionCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveResolutionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveResolutionCommand request, CancellationToken cancellationToken)
    {
        var resolution = await _context.Resolution.FindAsync(new object[] { request.Id }, cancellationToken);
        
        if (resolution == null)
        {
            throw new NotFoundException("Resolution not found" , nameof(resolution));
        }

        _context.Resolution.Remove(resolution);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
