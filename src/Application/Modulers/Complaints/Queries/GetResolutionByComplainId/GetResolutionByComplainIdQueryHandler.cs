using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Complaints.Queries.GetResolutionByComplainId;

public sealed class GetResolutionByComplainIdQueryHandler : IRequestHandler<GetResolutionByComplainIdQuery, List<ResolutionDto>>
{
    private readonly IApplicationDbContext _context;

    public GetResolutionByComplainIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ResolutionDto>> Handle(GetResolutionByComplainIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Resolution
            .Where(r => r.ComplintId == request.ComplintId)
            .ProjectToType<ResolutionDto>()
            .ToListAsync(cancellationToken);
    }
}
