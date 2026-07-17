using System;
using System.Collections.Generic;
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
    public Guid ProjectId {  get; private set; }
    public User? Responsibal {  get; private set; }
    public Guid ResponsibalId {  get; private set; }
}
