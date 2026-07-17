using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Bookings.Enum;

public enum BokingStatus
{
    UnCreated = 0,
    InReviewCustomer = 1,
    InReviewResponsibal = 2,
    Confirmed = 3,
    Cancelled = 4,
    Expired = 5,
    Delied = 6
}
public enum Decision
{
    Approved = 0,
    Rejected = 1,
    Pending = 2,
    Dely = 3
}
