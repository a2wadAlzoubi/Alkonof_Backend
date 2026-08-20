using System;
using System.Collections.Generic;
using System.Text;

namespace Alkonof_Backend.Domain.Entities.Identity.Enum;


public enum UserRole
{
    Admin = 0,
    Responsible = 1,
    Customer = 2,
}
public enum Specialization
{
    Civil = 0,
    Structural = 1,
    Architectural = 2,
    Mep = 3,
    Electrical = 4,
    Mechanical = 5,
    Geotechnical = 6,
    Surveying = 7,
    ProjectManagement = 8,
    SiteEngineer = 9,
    QaQc = 10,
    Hse = 11,
    QuantitySurveying = 12,
    None = 13,
}
public enum UserStatus
{
    Active = 0,
    Suspended = 1,
    Locked = 2,
    Deleted = 3,
    UnActive = 4,
}
public enum OperationPermission
{

    Booking=0,
    Meeting=1,
    Scheduling=2,
    Contract=3,
    ProjectStaff=4,
    Service=6,
    GrantPermission=5,
    CreateUser=7,
    CreateProject=8,
    CreateStage=9,
    CreateTask=10,
    Notification=11

}
public enum PermissionType
{

    Admin=0,
    Engineer=1,
    Formen=2,
    BookingResponsible=3,
    ComplainResponsible=4,


}
