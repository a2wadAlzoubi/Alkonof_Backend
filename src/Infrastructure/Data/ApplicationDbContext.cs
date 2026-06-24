using System.Reflection;
using Alkonof_Backend.Application.Common.Interfaces;
using Alkonof_Backend.Domain.Entities;
using Alkonof_Backend.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alkonof_Backend.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<AuditChange> AuditChange => Set<AuditChange>();

    public DbSet<AuditEntity> AuditEntity => Set<AuditEntity>();

    public DbSet<Complain> Complain => Set<Complain>();

    public DbSet<Notification> Notification => Set<Notification>();

    public DbSet<NotificationTemplet> NotificationTemplet => Set<NotificationTemplet>();

    public DbSet<Permission> Permission => Set<Permission>();

    public DbSet<Resolution> Resolution => Set<Resolution>();

    public DbSet<TimeTable> TimeTable => Set<TimeTable>();

    public DbSet<User> User => Set<User>();

    public DbSet<UserPermission> UserPermission => Set<UserPermission>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
