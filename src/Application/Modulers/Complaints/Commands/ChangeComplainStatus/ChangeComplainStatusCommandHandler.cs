using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.ChangeComplainStatus;

public sealed class ChangeComplainStatusCommandHandler : IRequestHandler<ChangeComplainStatusCommand>
{
    private readonly IApplicationDbContext _context;

    public ChangeComplainStatusCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(ChangeComplainStatusCommand request, CancellationToken cancellationToken)
    {
        var complain = await _context.Complain.FindAsync(new object[] { request.Dto.Id }, cancellationToken);
        
        if (complain == null)
        {
            throw new NotFoundException("Complain not found" , nameof(complain));
        }

        complain.ChangeComplainStatus(request.Dto.Status);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
