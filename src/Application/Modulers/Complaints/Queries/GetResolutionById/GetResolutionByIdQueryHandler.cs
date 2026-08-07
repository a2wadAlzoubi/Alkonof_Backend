using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Complaints.Queries.GetResolutionById;

public sealed class GetResolutionByIdQueryHandler : IRequestHandler<GetResolutionByIdQuery, ResolutionDto?>
{
    private readonly IApplicationDbContext _context;

    public GetResolutionByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResolutionDto?> Handle(GetResolutionByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Resolution
            .ProjectToType<ResolutionDto>()
            .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
    }
}
