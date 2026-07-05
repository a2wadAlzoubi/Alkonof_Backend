using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class Project : BaseAuditableEntity
{
    private Project()
    {
        
    }
    private Project(
        Guid id,
        ProjectStatus status,
        string title,
        string description,
        string location ,
        DateTimeOffset? ActualEngedDate ,
        double Progress)
    {
        Id = id;
        Status = status;
        Title = title;
        Description = description;
        Location = location;
    }

    public ProjectStatus Status {  get; private set; }
    public string Title {  get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Location { get; private set; } = string.Empty;
    public DateTimeOffset? ActualEngedDate { get; private set; }
    public double Progress { get; private set; }

    //Realational
    public Contract? Contract { get; private set; }
    public List<ProjectStaff>? ProjectStaffs { get; private set; }
    public List<Stage>? Stages { get; private set; }

    
}
