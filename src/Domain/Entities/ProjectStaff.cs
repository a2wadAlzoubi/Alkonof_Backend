using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class ProjectStaff
{
    private ProjectStaff() { }
    private ProjectStaff(int id,int projectid,int respnsibalid)
    {
        Id = id;
        ProjectId = projectid;
        ResponsibalId = respnsibalid;
    }
    public int Id { get; set; }
    public int ProjectId {  get; set; }
    public int ResponsibalId {  get; set; }
}
