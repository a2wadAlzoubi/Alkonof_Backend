namespace Alkonof_Backend.Domain.Enums;

public enum AuditAction
{
    bookingAssinged =0,
    meetingCompleted = 1,
    projectCreated = 2,
    permissionGranted = 3
}

public enum AuditCatigory
{
    create = 0,
    update = 1,
    delete = 2,
    statusCharge = 3,
    permissionChange = 4,
    assignment = 5,
    workflow = 6
}

public enum NotificationStatus
{
    unRead = 0,
    read = 1,
}

public enum ReferenceType
{
    booking = 0,
    meeting = 1,
    contract = 2,
    project = 3,
    projectStage = 4,
    projectTask = 5,
    schadualing = 6,
    identity = 7,
    complain = 8,
    non = 9
}
