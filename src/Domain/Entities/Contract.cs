using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class Contract
{
  private Contract(int id, DateTimeOffset date, string pathImage, string projectType, Booking booking, Project project, int bokingId, int projectId)
    {
        Id = id;
        Date = date;
        PathImage = pathImage;
        ProjectType = projectType;
        Booking = booking;
        Project = project;
        BokingId = bokingId;
        ProjectId = projectId;
    }

    public int Id { get; set; }
    public DateTimeOffset Date {  get; set; }
    public string PathImage {  get; set; }
    public string ProjectType {  get; set; }
    
    //Relatinal
    public Booking Booking { get; set; }
    public Project Project { get; set; }
   
    
    //Forign Key
    public int BokingId {  get; set; }
    public int ProjectId {  get; set; }
   
    
    //Enum
    public enum enContrucStatus
    {
        OnWorking=0,
        Archeved=1
    }
    public enum enProjectType
    {
        Advisory=0,
        Field=1
    }
}
