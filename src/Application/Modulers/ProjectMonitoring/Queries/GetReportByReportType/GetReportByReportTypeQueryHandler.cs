using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetReportByReportType;

public class GetReportByReportTypeQueryHandler : IRequestHandler<GetReportByReportTypeQuery, List<ProjectReportDto>>
{
    private readonly IApplicationDbContext _context;

    public GetReportByReportTypeQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectReportDto>> Handle(GetReportByReportTypeQuery request, CancellationToken cancellationToken)
    {
        return await _context.ProjectReport
            .ProjectToType<ProjectReportDto>()
            .Where(pr => pr.ReportType == request.ReportType)
            .ToListAsync(cancellationToken);
    }
}
