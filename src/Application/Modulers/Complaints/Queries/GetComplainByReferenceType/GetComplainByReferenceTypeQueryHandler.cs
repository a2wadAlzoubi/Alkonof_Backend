using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Complaints.Queries.GetComplainByReferenceType;

public sealed class GetComplainByReferenceTypeQueryHandler : IRequestHandler<GetComplainByReferenceTypeQuery, List<ComplainDto>>
{
    private readonly IApplicationDbContext _context;

    public GetComplainByReferenceTypeQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ComplainDto>> Handle(GetComplainByReferenceTypeQuery request, CancellationToken cancellationToken)
    {
        return await _context.Complain
            .Where(c => c.ReferenceType == request.ReferenceType)
            .ProjectToType<ComplainDto>()
            .ToListAsync(cancellationToken);
    }
}
