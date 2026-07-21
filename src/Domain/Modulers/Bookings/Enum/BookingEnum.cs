using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Bookings.Enum;

public enum BookingStatus
{
    UnCreated = 0,
    InReviewCustomer = 1,
    InReviewResponsible = 2,
    Confirmed = 3,
    Cancelled = 4,
    Expired = 5,
    Delaied = 6
}
public enum Decision
{
    Approved = 0,
    Rejected = 1,
    Pending = 2,
    Delay = 3
}
public enum ServiceType
{
    Informaticse = 0,
    Civial = 1,
    Decor = 2,
}
