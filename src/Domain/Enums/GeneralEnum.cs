using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Enums;

public enum ReferenceType
{
    Booking = 0,
    Meeting = 1,
    Contract = 2,
    Project = 3,
    ProjectStage = 4,
    ProjectTask = 5,
    Schadualing = 6,
    Identity = 7,
    Complain = 8,
    Non = 9
}
public enum PriorityLevel
{
    None = 0,
    Low = 1,
    Medium = 2,
    High = 3
}
