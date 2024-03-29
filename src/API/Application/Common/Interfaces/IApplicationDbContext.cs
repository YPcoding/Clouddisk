﻿using Domain.Entities.Audit;
using Domain.Entities.Departments;
using Domain.Entities.Identity;
using Domain.Entities.Job;
using Domain.Entities.Loggers;
using Domain.Entities.Notifications;
using Domain.Entities.Settings;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Common.Interfaces;

public  interface IApplicationDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<AuditTrail> AuditTrails { get; set; }
    DbSet<Logger> Loggers { get; set; }
    DbSet<Role> Roles { get; }
    DbSet<UserRole> UserRoles { get; }
    DbSet<Notification> Notifications { get; }
    DbSet<UserProfileSetting> UserProfileSettings { get; }
    DbSet<Department> Departments { get; }
    DbSet<Menu> Menus { get; }
    DbSet<RoleMenu> RoleMenus { get; }
    DbSet<ScheduledJob> ScheduledJobs { get; }
    DbSet<Document> Documents { get; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
    DatabaseFacade Database { get; }
    EntityEntry Entry(object entity);
}
