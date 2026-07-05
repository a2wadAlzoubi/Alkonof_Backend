using System.Reflection;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities;
using Alkonof_Backend.Infrastructure.Identity;
using Domain.RefreshTokens;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<AuditChange> AuditChange => Set<AuditChange>();
    public DbSet<BookingType> BookingType => Set<BookingType>();

    public DbSet<AuditEntity> AuditEntity => Set<AuditEntity>();

    public DbSet<Complain> Complain => Set<Complain>();

    public DbSet<Notification> Notification => Set<Notification>();

    public DbSet<NotificationTemplet> NotificationTemplet => Set<NotificationTemplet>();

    public DbSet<Permission> Permission => Set<Permission>();

    public DbSet<Resolution> Resolution => Set<Resolution>();

    public DbSet<TimeTable> TimeTable => Set<TimeTable>();

    public DbSet<User> User => Set<User>();
    public DbSet<RefreshToken> RefreshToken => Set<RefreshToken>();

    public DbSet<UserPermission> UserPermission => Set<UserPermission>();

    public DbSet<Booking> Booking => throw new NotImplementedException();

    public DbSet<Contract> Contract => throw new NotImplementedException();

    public DbSet<Meeting> Meeting => throw new NotImplementedException();

    public DbSet<OrderBooking> OrderBooking => throw new NotImplementedException();

    public DbSet<PermissionGrop> PermissionGrop => throw new NotImplementedException();

    public DbSet<PrepareMeeting> PrepareMeeting => throw new NotImplementedException();

    public DbSet<Project> Project => throw new NotImplementedException();

    public DbSet<ProjectReport> ProjectReport => throw new NotImplementedException();

    public DbSet<ProjectStaff> ProjectStaff => throw new NotImplementedException();

    public DbSet<Stage> Stage => throw new NotImplementedException();

    public DbSet<StageImage> StageImage => throw new NotImplementedException();

    public DbSet<TaskTabel> TaskTabel => throw new NotImplementedException();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
