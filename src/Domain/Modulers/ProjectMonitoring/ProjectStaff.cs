using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Alkonof_Backend.Domain.Entities.Identity;

namespace Alkonof_Backend.Domain.Entities.ProjectMonitoring;

public class ProjectStaff : BaseAuditableEntity
{
    private ProjectStaff() { }
    private ProjectStaff(Guid id,Guid projectid,Guid respnsibalid)
    {
        Id = id;
        ProjectId = projectid;
        ResponsibalId = respnsibalid;
    }
    public Project? Project {  get; private set; }
    [Required]
    public Guid ProjectId {  get; private set; }
    public User? Responsibal {  get; private set; }
    [Required]
    public Guid ResponsibalId {  get; private set; }
    public static ProjectStaff CreateProjectStaff(Guid projectid, Guid respnsibalid)
    {
        return new ProjectStaff(projectid, projectid, respnsibalid);
    }
    public void UpdateProjectStaff(Guid projectid, Guid respnsibalid)
    {
        ProjectId = projectid;
        ResponsibalId = respnsibalid;
    }
}
