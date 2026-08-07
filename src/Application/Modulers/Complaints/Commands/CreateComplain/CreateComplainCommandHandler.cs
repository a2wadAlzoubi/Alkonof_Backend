using Alkonof_Backend.Domain.Entities.Complains;
using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Alkonof_Backend.Application.Common.Interfaces;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.CreateComplain;

public sealed class CreateComplainCommandHandler : IRequestHandler<CreateComplainCommand, Guid?>
{
    private readonly IApplicationDbContext _context;

    public CreateComplainCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid?> Handle(CreateComplainCommand request, CancellationToken cancellationToken)
    {
        var complain = Complain.Create(
            request.Dto.Status,
            request.Dto.Subject,
            request.Dto.ReferenceType,
            request.Dto.Content,
            request.Dto.CustomerId
        );

        _context.Complain.Add(complain);
        await _context.SaveChangesAsync(cancellationToken);
        return complain.Id;
    }
}
