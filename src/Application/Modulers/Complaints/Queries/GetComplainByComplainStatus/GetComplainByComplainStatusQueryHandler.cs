using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Complaints.Queries.GetComplainByComplainStatus;

public sealed class GetComplainByComplainStatusQueryHandler : IRequestHandler<GetComplainByComplainStatusQuery, List<ComplainDto>>
{
    private readonly IApplicationDbContext _context;

    public GetComplainByComplainStatusQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ComplainDto>> Handle(GetComplainByComplainStatusQuery request, CancellationToken cancellationToken)
    {
        return await _context.Complain
            .Where(c => c.Status == request.Status)
            .ProjectToType<ComplainDto>()
            .ToListAsync(cancellationToken);
    }
}
