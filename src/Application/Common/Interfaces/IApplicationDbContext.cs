using Alkonof_Backend.Domain.Entities;

namespace Alkonof_Backend.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }
    DbSet<AuditChange> AuditChange { get; }
    DbSet<AuditEntity> AuditEntity { get; }
    DbSet<Complain> Complain { get; }
    DbSet<Notification> Notification { get; }
    DbSet<NotificationTemplet> NotificationTemplet { get; }
    DbSet<Permission> Permission { get; }
    DbSet<Resolution> Resolution { get; }
    DbSet<TimeTable> TimeTable { get; }
    DbSet<User> User { get; }

    DbSet<UserPermission> UserPermission { get; }
    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
