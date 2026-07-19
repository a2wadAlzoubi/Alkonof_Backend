using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;


public enum ProjectStatus
{
    Created = 0,
    Started = 1,
    InProgress = 2,
    OnHold = 3,
    Completed = 4,
    Cancelled = 5
}
public enum StageStatus
{
    NotStarted = 0,
    InProgress = 1,
    Completed = 2,
    Cancelled = 3
}

public enum ReportType
{
    Daily = 0,
    Weekly = 1,
    General = 3
}
