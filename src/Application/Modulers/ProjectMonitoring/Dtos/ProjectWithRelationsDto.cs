using System.Collections.Generic;

namespace Alkonof_Backend.Application.Modulers.ProjectMonitoring.Dtos;

public class ProjectWithRelationsDto : ProjectDto
{
    public List<StageDto> Stages { get; set; } = new List<StageDto>();
    public List<ProjectStaffDto> ProjectStaffs { get; set; } = new List<ProjectStaffDto>();
    public List<ProjectReportDto> ProjectReports { get; set; } = new List<ProjectReportDto>();
}
