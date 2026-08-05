using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetResponsiblesByProjectId;

public class GetResponsiblesByProjectIdQueryHandler : IRequestHandler<GetResponsiblesByProjectIdQuery, List<ProjectStaffDto>>
{
    private readonly IApplicationDbContext _context;

    public GetResponsiblesByProjectIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectStaffDto>> Handle(GetResponsiblesByProjectIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.ProjectStaff
            .ProjectToType<ProjectStaffDto>()
            .Where(ps => ps.ProjectId == request.ProjectId)
            .ToListAsync(cancellationToken);
    }
}
