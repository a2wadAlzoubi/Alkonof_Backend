using Alkonof_Backend.Application.Common.Exceptions;
using Alkonof_Backend.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.UpdateComplain;

public sealed class UpdateComplainCommandHandler : IRequestHandler<UpdateComplainCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateComplainCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateComplainCommand request, CancellationToken cancellationToken)
    {
        var complain = await _context.Complain.FindAsync(new object[] { request.Dto.Id }, cancellationToken);
        
        if (complain == null)
        {
            throw new NotFoundException("Complain not found" , nameof(complain));
        }

        complain.Update(
            request.Dto.Status,
            request.Dto.Subject,
            request.Dto.ReferenceType,
            request.Dto.Content,
            request.Dto.CustomerId
        );

        await _context.SaveChangesAsync(cancellationToken);
    }
}
