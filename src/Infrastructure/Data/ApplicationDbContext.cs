using System.Reflection;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities;
using Alkonof_Backend.Domain.Entities.Audits;
using Alkonof_Backend.Domain.Entities.Bookings;
using Alkonof_Backend.Domain.Entities.Complains;
using Alkonof_Backend.Domain.Entities.Contracts;
using Alkonof_Backend.Domain.Entities.Identity;
using Alkonof_Backend.Domain.Entities.Meetings;
using Alkonof_Backend.Domain.Entities.Notifications;
using Alkonof_Backend.Domain.Entities.ProjectMonitoring;
using Alkonof_Backend.Domain.Entities.Schedualing;
using Alkonof_Backend.Infrastructure.Identity;
using Domain.RefreshTokens;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<AuditChange> AuditChange => Set<AuditChange>();
    public DbSet<Service> Service => Set<Service>();

    public DbSet<AuditEntity> AuditEntity => Set<AuditEntity>();

    public DbSet<Complain> Complain => Set<Complain>();

    public DbSet<Notification> Notification => Set<Notification>();

    public DbSet<NotificationTemplet> NotificationTemplet => Set<NotificationTemplet>();

    public DbSet<Permission> Permission => Set<Permission>();

    public DbSet<Resolution> Resolution => Set<Resolution>();

    public DbSet<TimeTable> TimeTable => Set<TimeTable>();

    public DbSet<User> User => Set<User>();
    public DbSet<RefreshToken> RefreshToken => Set<RefreshToken>();
    public DbSet<Booking> Booking => Set<Booking>();
    public DbSet<Contract> Contract => Set<Contract>();
    public DbSet<Meeting> Meeting => Set<Meeting>();
    public DbSet<OrderBooking> OrderBooking => Set<OrderBooking>();
    public DbSet<PermissionGrop> PermissionGrop => Set<PermissionGrop>();
    public DbSet<PrepareMeeting> PrepareMeeting => Set<PrepareMeeting>();
    public DbSet<Project> Project =>Set<Project>();
    public DbSet<ProjectReport> ProjectReport =>Set<ProjectReport>();
    public DbSet<ProjectStaff> ProjectStaff =>  Set<ProjectStaff>();
    public DbSet<Stage> Stage => Set<Stage>();
    public DbSet<StageImage> StageImage => Set<StageImage>();
    public DbSet<TaskTabel> TaskTabel => Set<TaskTabel>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
