using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Alkonof_Backend.Domain.Entities.Contracts;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;

namespace Alkonof_Backend.Domain.Entities.ProjectMonitoring;

public class Project : BaseAuditableEntity
{
    private Project()
    {
        
    }
    private Project(
        Guid id,
        string title,
        string description,
        string location ,
        DateTimeOffset? ActualEngedDate ,
        double Progress,
        ProjectStatus status = ProjectStatus.Created
        )
    {
        Id = id;
        Status = status;
        Title = title;
        Description = description;
        Location = location;
    }
    [Required]
    public ProjectStatus Status {  get; private set; }
    [Required]
    public string Title {  get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    [Required]
    public string Location { get; private set; } = string.Empty;
    public DateTimeOffset? EndDate { get; private set; }
    [Required]
    public double Progress { get; private set; } = 0;

    //Realational
    public Contract? Contract { get; private set; }
    public List<ProjectStaff>? ProjectStaffs { get; private set; }
    public List<Stage>? Stages { get; private set; }

    public static Project CreateProject(
         string title,
        string description,
        string location,
        DateTimeOffset? ActualEngedDate,
        double Progress,
        ProjectStatus status = ProjectStatus.Created)
    {
        var project = new Project(Guid.NewGuid() , title , description , location , ActualEngedDate , Progress , status);
        return project;
    }
    public void UpdateProject(
         string title,
        string description,
        string location,
        DateTimeOffset? ActualEngedDate,
        double Progress,
        ProjectStatus status = ProjectStatus.Created)
    {
        Status = status;
        Title = title;
        Description = description;
        Location = location;
    }
     public void ChangeProjectState(ProjectStatus status)
    {
        Status = status;
    }
     public void SetActualEndDate(DateTimeOffset dateTime)
    {
        EndDate = dateTime;
    }
     public void SetProgress(double progress)
    {
        Progress = progress;
    }
}
