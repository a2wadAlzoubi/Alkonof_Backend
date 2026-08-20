using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Queries.GetProjectByCustomerIdWithRelaited;

public class GetProjectByCustomerIdWithRelaitedQueryHandler : IRequestHandler<GetProjectByCustomerIdWithRelaitedQuery, List<ProjectWithRelationsDto>>
{
    private readonly IApplicationDbContext _context;

    public GetProjectByCustomerIdWithRelaitedQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectWithRelationsDto>> Handle(GetProjectByCustomerIdWithRelaitedQuery request, CancellationToken cancellationToken)
    {
        // افتراض أن Project تحتوي على CustomerId (الخاصية موجودة في الكيان الأساسي)
        var projects = await _context.Project
            //.Where(p => EF.Property<Guid>(p, "CustomerId") == request.CustomerId)
            .Where(p => p.Contract != null && p.Contract.Booking != null)
            .Where(p => p.Contract!.Booking!.CustomerId == request.CustomerId)
            .ProjectToType<ProjectWithRelationsDto>()
            .ToListAsync(cancellationToken);

        // تحميل العلاقات لكل مشروع
        foreach (var project in projects)
        {
            project.Stages = await _context.Stage
                .ProjectToType<StageDto>()
                .Where(s => s.ProjectId == project.Id)
                .ToListAsync(cancellationToken);

            project.ProjectStaffs = await _context.ProjectStaff
                .ProjectToType<ProjectStaffDto>()
                .Where(ps => ps.ProjectId == project.Id)
                .ToListAsync(cancellationToken);

            project.ProjectReports = await _context.ProjectReport
                .ProjectToType<ProjectReportDto>()
                .Where(pr => pr.ProjectId == project.Id)
                .ToListAsync(cancellationToken);
        }

        return projects;
    }
}
