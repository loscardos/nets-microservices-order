﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderService.Infrastructure.Databases;

#nullable disable

namespace OrderService.Migrations
{
    [DbContext(typeof(IamDBContext))]
    [Migration("20250107110929_CreateOrderTable")]
    partial class CreateOrderTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderService.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("content");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Href")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("href");

                    b.Property<bool>("IsRead")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("is_read");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_notifications");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_notifications_user_id");

                    b.ToTable("notifications", (string)null);
                });

            modelBuilder.Entity("OrderService.Models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Key")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("key");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_permissions");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_permissions_id");

                    b.HasIndex("Key")
                        .IsUnique()
                        .HasDatabaseName("ix_permissions_key")
                        .HasFilter("[key] IS NOT NULL");

                    b.ToTable("permissions", (string)null);
                });

            modelBuilder.Entity("OrderService.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Key")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("key");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_roles_id");

                    b.HasIndex("Key")
                        .IsUnique()
                        .HasDatabaseName("ix_roles_key")
                        .HasFilter("[key] IS NOT NULL");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("OrderService.Models.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("permission_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("role_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_role_permissions");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_role_permissions_id");

                    b.HasIndex("PermissionId")
                        .HasDatabaseName("ix_role_permissions_permission_id");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_role_permissions_role_id");

                    b.ToTable("role_permissions", (string)null);
                });

            modelBuilder.Entity("OrderService.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email")
                        .HasFilter("[email] IS NOT NULL");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_users_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("OrderService.Models.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("role_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_roles");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_user_roles_id");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_user_roles_role_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_roles_user_id");

                    b.ToTable("user_roles", (string)null);
                });

            modelBuilder.Entity("OrderService.Models.Notification", b =>
                {
                    b.HasOne("OrderService.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_notifications_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrderService.Models.RolePermission", b =>
                {
                    b.HasOne("OrderService.Models.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_permissions_permissions_permission_id");

                    b.HasOne("OrderService.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_permissions_roles_role_id");

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OrderService.Models.UserRole", b =>
                {
                    b.HasOne("OrderService.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_roles_roles_role_id");

                    b.HasOne("OrderService.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_roles_users_user_id");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrderService.Models.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("OrderService.Models.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("OrderService.Models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
