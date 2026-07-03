using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class Project
{
    private Project(int id, string status, string title, string description, string location)
    {
        Id = id;
        Status = status;
        Title = title;
        Description = description;
        Location = location;
    }

    public int Id { get; set; }
    public string Status {  get; set; }
    public String Title {  get; set; }
    public string Description { get; set; }
    public string Location {  get; set; }

    //Realational
    public List<ProjectStaff>? StaffList { get; set; }
    public List<Stage>? Stages { get; set; }
    //forgin Key


    
}
