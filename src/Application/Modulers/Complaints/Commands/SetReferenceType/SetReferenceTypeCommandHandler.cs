using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.SetReferenceType;

public sealed class SetReferenceTypeCommandHandler : IRequestHandler<SetReferenceTypeCommand>
{
    private readonly IApplicationDbContext _context;

    public SetReferenceTypeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(SetReferenceTypeCommand request, CancellationToken cancellationToken)
    {
        var complain = await _context.Complain.FindAsync(new object[] { request.Dto.Id }, cancellationToken);
        
        if (complain == null)
        {
            throw new NotFoundException("Complain not found" , nameof(complain));
        }

        complain.SetReferenceType(request.Dto.ReferenceType);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
