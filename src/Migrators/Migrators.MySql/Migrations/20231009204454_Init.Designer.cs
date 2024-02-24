﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Migrators.MySql.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231009204454_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Audit.AuditTrail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("AffectedColumns")
                        .HasColumnType("longtext");

                    b.Property<string>("AuditType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NewValues")
                        .HasColumnType("longtext");

                    b.Property<string>("OldValues")
                        .HasColumnType("longtext");

                    b.Property<string>("PrimaryKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TableName")
                        .HasColumnType("longtext");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AuditTrails");
                });

            modelBuilder.Entity("Domain.Entities.Departments.Department", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<long?>("SuperiorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SuperiorId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Domain.Entities.Identity.Menu", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Active")
                        .HasColumnType("longtext");

                    b.Property<string>("Code")
                        .HasColumnType("longtext");

                    b.Property<string>("Component")
                        .HasColumnType("longtext");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("HttpMethods")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Path")
                        .HasColumnType("longtext");

                    b.Property<string>("Redirect")
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Domain.Entities.Identity.RoleMenu", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<long>("MenuId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleMenus");
                });

            modelBuilder.Entity("Domain.Entities.Identity.User", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("longtext");

                    b.Property<long?>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("EmailConfirmed")
                        .HasMaxLength(1)
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("GenderType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsLive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsSystemAccount")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasMaxLength(1)
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nickname")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasMaxLength(1)
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProfilePictureDataUrl")
                        .HasColumnType("text");

                    b.Property<string>("Realname")
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Signature")
                        .HasColumnType("longtext");

                    b.Property<long?>("SuperiorId")
                        .HasColumnType("bigint");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasMaxLength(1)
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SuperiorId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Loggers.Logger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Exception")
                        .HasColumnType("longtext");

                    b.Property<string>("Level")
                        .HasColumnType("longtext");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<string>("Properties")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("TS")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("_ts");

                    b.Property<string>("Template")
                        .HasColumnType("longtext");

                    b.Property<string>("Timestamp")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Loggers");
                });

            modelBuilder.Entity("Domain.Entities.Notifications.Notification", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<int>("NotificationType")
                        .HasColumnType("int");

                    b.Property<long?>("SenderId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Domain.Entities.Notifications.NotificationRecipient", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<int>("NotificationId")
                        .HasColumnType("int");

                    b.Property<long>("NotificationId1")
                        .HasColumnType("bigint");

                    b.Property<int>("RecipientId")
                        .HasColumnType("int");

                    b.Property<long>("RecipientId1")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId1");

                    b.HasIndex("RecipientId1");

                    b.ToTable("NotificationRecipient");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Entities.Settings.UserProfileSetting", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("DefaultValue")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("SettingName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SettingValue")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("ValueType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfileSettings");
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.Audit.AuditTrail", b =>
                {
                    b.HasOne("Domain.Entities.Identity.User", "Owner")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Entities.Departments.Department", b =>
                {
                    b.HasOne("Domain.Entities.Departments.Department", "Superior")
                        .WithMany()
                        .HasForeignKey("SuperiorId");

                    b.Navigation("Superior");
                });

            modelBuilder.Entity("Domain.Entities.Identity.Menu", b =>
                {
                    b.HasOne("Domain.Entities.Identity.Menu", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.OwnsOne("Domain.ValueObjects.Meta", "Meta", b1 =>
                        {
                            b1.Property<long>("MenuId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Active")
                                .HasColumnType("longtext");

                            b1.Property<string>("Color")
                                .HasColumnType("longtext");

                            b1.Property<bool?>("Fullpage")
                                .HasColumnType("tinyint(1)");

                            b1.Property<bool?>("Hidden")
                                .HasColumnType("tinyint(1)");

                            b1.Property<bool?>("HiddenBreadcrumb")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("Icon")
                                .HasColumnType("longtext");

                            b1.Property<string>("Tag")
                                .HasColumnType("longtext");

                            b1.Property<string>("Title")
                                .HasColumnType("longtext");

                            b1.Property<string>("Type")
                                .HasColumnType("longtext");

                            b1.HasKey("MenuId");

                            b1.ToTable("Menus");

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.Navigation("Meta");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Domain.Entities.Identity.RoleMenu", b =>
                {
                    b.HasOne("Domain.Entities.Identity.Menu", "Menu")
                        .WithMany("RoleMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.Identity.User", b =>
                {
                    b.HasOne("Domain.Entities.Departments.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Domain.Entities.Identity.User", "Superior")
                        .WithMany()
                        .HasForeignKey("SuperiorId");

                    b.Navigation("Department");

                    b.Navigation("Superior");
                });

            modelBuilder.Entity("Domain.Entities.Notifications.Notification", b =>
                {
                    b.HasOne("Domain.Entities.Identity.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Domain.Entities.Notifications.NotificationRecipient", b =>
                {
                    b.HasOne("Domain.Entities.Notifications.Notification", "Notification")
                        .WithMany("Recipients")
                        .HasForeignKey("NotificationId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Identity.User", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notification");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("Domain.Entities.Settings.UserProfileSetting", b =>
                {
                    b.HasOne("Domain.Entities.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Identity.Menu", b =>
                {
                    b.Navigation("RoleMenus");
                });

            modelBuilder.Entity("Domain.Entities.Identity.User", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.Notifications.Notification", b =>
                {
                    b.Navigation("Recipients");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("RoleMenus");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
