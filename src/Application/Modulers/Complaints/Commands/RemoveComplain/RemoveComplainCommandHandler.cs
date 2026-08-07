using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.RemoveComplain;

public sealed class RemoveComplainCommandHandler : IRequestHandler<RemoveComplainCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveComplainCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveComplainCommand request, CancellationToken cancellationToken)
    {
        var complain = await _context.Complain.FindAsync(new object[] { request.Id }, cancellationToken);
        
        if (complain == null)
        {
            throw new NotFoundException("Complain not found" , nameof(complain));
        }

        _context.Complain.Remove(complain);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
