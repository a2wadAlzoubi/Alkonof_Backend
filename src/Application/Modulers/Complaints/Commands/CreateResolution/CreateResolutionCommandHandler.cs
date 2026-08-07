using Alkonof_Backend.Domain.Entities.Complains;
using Alkonof_Backend.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Complaints.Commands.CreateResolution;

public sealed class CreateResolutionCommandHandler : IRequestHandler<CreateResolutionCommand, Guid?>
{
    private readonly IApplicationDbContext _context;

    public CreateResolutionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid?> Handle(CreateResolutionCommand request, CancellationToken cancellationToken)
    {
        var resolution = Resolution.Create(
            request.Dto.ComplintId,
            request.Dto.ResolutionText
        );

        _context.Resolution.Add(resolution);
        await _context.SaveChangesAsync(cancellationToken);
        return resolution.Id;
    }
}
