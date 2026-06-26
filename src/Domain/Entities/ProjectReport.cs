using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities;

public class ProjectReport
{
    private ProjectReport(int id, int stageId, string type, string title, string content)
    {
        Id = id;
        StageId = stageId;
        Type = type;
        Title = title;
        Content = content;
    }

    public int Id { get; set; }
    public int StageId {  get; set; }
    public string Type {  get; set; }
    public string Title {  get; set; }
    public string Content {  get; set; }

}
