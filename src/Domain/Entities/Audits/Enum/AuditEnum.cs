using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Audits.Enum;

public enum AuditAction
{
    bookingAssinged = 0,
    meetingCompleted = 1,
    projectCreated = 2,
    permissionGranted = 3,
    unknown = 4,
}
public enum AuditCategory
{
    create = 0,
    update = 1,
    delete = 2,
    statusCharge = 3,
    permissionChange = 4,
    assignment = 5,
    workflow = 6,
    unknown = 7,

}
