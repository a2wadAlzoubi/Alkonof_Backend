namespace Alkonof_Backend.Domain.Enums;

public enum PriorityLevel
{
    None = 0,
    Low = 1,
    Medium = 2,
    High = 3
}
public enum ProjectStatus
{
    Created=0,
    Planeng=1,
    ReadyToStart=2,
    InProgress=3,
    OnHold=4,
    Completed=5,
    Delivered=6,
    Warranty=7,
    Closed=8,
    Cancelled=9
}
public enum Task_StageStatus
{
    NotStarted=0,
    InProgress=1,
    Completed=2,
    Cancelled=3
}
public enum TaskPriority
{
    Low = 1,
    Medium = 2,
    High = 3,
    Critical=4
}
public enum ReprotType
{
    Daily=0,
    Weekly=1,
    General=3
}
