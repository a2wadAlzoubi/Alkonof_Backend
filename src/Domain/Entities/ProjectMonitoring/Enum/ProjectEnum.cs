using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.ProjectMonitoring.Enum;


public enum ProjectStatus
{
    Created = 0,
    Planeng = 1,
    ReadyToStart = 2,
    InProgress = 3,
    OnHold = 4,
    Completed = 5,
    Delivered = 6,
    Warranty = 7,
    Closed = 8,
    Cancelled = 9
}
public enum Task_StageStatus
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
