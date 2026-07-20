using Alkonof_Backend.Domain.Entities.Audits;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Complains;
using Alkonof_Backend.Domain.Entities.Contracts;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Entities.Notifications;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using Alkonof_Backend.Domain.Entities.Schedualing;
using Domain.RefreshTokens;

namespace Alkonof_Backend.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<AuditChange> AuditChange { get; }
    DbSet<AuditEntity> AuditEntity{ get; }
    DbSet<Booking> Booking { get; }
    DbSet<BookingType> BookingType { get; }
    DbSet<Complain> Complain { get; }
    DbSet<Contract> Contract { get; }
    DbSet<Meeting> Meeting { get; }
    DbSet<Notification> Notification { get; }
    DbSet<NotificationTemplet> NotificationTemplet { get; }
    DbSet<OrderBooking> OrderBooking { get; }
    DbSet<Permission> Permission { get; }
    DbSet<PermissionGrop> PermissionGrop { get; }
    DbSet<PrepareMeeting> PrepareMeeting { get; }
    DbSet<Project> Project { get; }
    DbSet<ProjectReport> ProjectReport { get; }
    DbSet<ProjectStaff> ProjectStaff { get; }
    DbSet<Stage> Stage { get; }
    DbSet<StageImage> StageImage { get; }
    DbSet<TaskTabel> TaskTabel { get; }
    DbSet<Resolution> Resolution { get; }
    DbSet<TimeTable> TimeTable { get; }
    DbSet<User> User { get; }
    DbSet<RefreshToken> RefreshToken { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
