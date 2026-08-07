using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.Complaints.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Application.Modulers.Complaints.Queries.GetComplainById;

public sealed class GetComplainByIdQueryHandler : IRequestHandler<GetComplainByIdQuery, ComplainDto?>
{
    private readonly IApplicationDbContext _context;

    public GetComplainByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ComplainDto?> Handle(GetComplainByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Complain
            .ProjectToType<ComplainDto>()
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
    }
}
