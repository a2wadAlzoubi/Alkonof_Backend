using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class Contract : BaseAuditableEntity
{
    private Contract()
    {
        
    }
    private Contract(Guid id ,DateTimeOffset date, string pathImage, ProjectType type, Guid projectId)
    {
        Id = id;
        Date = date;
        PathImage = pathImage;
        Type = type;
        ProjectId = projectId;
    }

    public DateTimeOffset Date {  get; private set; }
    public string PathImage {  get; private set; } = string.Empty;
    public ProjectType Type { get; private set; } = ProjectType.Non;

    //Relatinal
    public Booking? Booking { get; private set; }
    public Project? Project { get; private set; }
    public Guid? ProjectId { get; private set; }
   
    
   
    
    //Enum
    public enum ContrucStatus
    {
        OnWorking=0,
        Archeved=1
    }
    public enum ProjectType
    {
        Advisory=0,
        Field=1 , 
        Non = 2
    }
}
