﻿// <auto-generated />
using System;
using Amirez.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Amirez.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221028160620_addPeriods")]
    partial class addPeriods
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("Amirez.Infrastructure.Data.HistoryDataModel<Amirez.Infrastructure.Data.Model.Common.TaskDataModel>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("date");

                    b.Property<int>("Operation")
                        .HasColumnType("INTEGER")
                        .HasColumnName("operation");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT")
                        .HasColumnName("parent_id");

                    b.Property<Guid>("VersionId")
                        .HasColumnType("TEXT")
                        .HasColumnName("version_id");

                    b.HasKey("Id")
                        .HasName("pk_history");

                    b.HasIndex("ParentId")
                        .HasDatabaseName("ix_history_parent_id");

                    b.HasIndex("VersionId")
                        .IsUnique()
                        .HasDatabaseName("ix_history_version_id");

                    b.ToTable("History");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Authentication.RoleDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("normalized_name");

                    b.Property<int>("RoleType")
                        .HasColumnType("INTEGER")
                        .HasColumnName("role_type");

                    b.HasKey("Id")
                        .HasName("pk_role");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fb8071a3-d9e9-4840-a238-dd555df5cdcc"),
                            ConcurrencyStamp = "d5e73d7c-4709-4e16-9819-c7151fe66a48",
                            Name = "Administrateur",
                            RoleType = 1
                        },
                        new
                        {
                            Id = new Guid("437ec833-24aa-4cef-aabb-ffa6ab8a8b74"),
                            ConcurrencyStamp = "7d9ef546-8e1a-40f1-92d6-365083b452d5",
                            Name = "Cb",
                            RoleType = 2
                        },
                        new
                        {
                            Id = new Guid("5f205bde-f1a9-4fab-aece-b7626e45b4d5"),
                            ConcurrencyStamp = "93c5518d-3d5e-4cd3-864e-162223ca1302",
                            Name = "Ruo",
                            RoleType = 3
                        },
                        new
                        {
                            Id = new Guid("4cb6d4c2-e5c4-4f45-874f-5e8495ac689d"),
                            ConcurrencyStamp = "51b17d2f-0d34-41ab-81aa-294d102ed31b",
                            Name = "Superviseur",
                            RoleType = 4
                        });
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Authentication.UtilisateurDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER")
                        .HasColumnName("access_failed_count");

                    b.Property<bool>("Bloque")
                        .HasColumnType("INTEGER")
                        .HasColumnName("bloque");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT")
                        .HasColumnName("lockout_end");

                    b.Property<string>("Nom")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT")
                        .HasColumnName("nom");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("Prenom")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT")
                        .HasColumnName("prenom");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT")
                        .HasColumnName("role_id");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_utilisateur");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_utilisateur_role_id");

                    b.ToTable("utilisateur");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Budget.BudgetCategoryDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_budget_category");

                    b.ToTable("budget_category");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Budget.BudgetPlanDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<double>("Ammount")
                        .HasColumnType("REAL")
                        .HasColumnName("ammount");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("TEXT")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("date");

                    b.Property<bool>("Paid")
                        .HasColumnType("INTEGER")
                        .HasColumnName("paid");

                    b.Property<bool>("Repeat")
                        .HasColumnType("INTEGER")
                        .HasColumnName("repeat");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT")
                        .HasColumnName("subject");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_budget_plan");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_budget_plan_category_id");

                    b.ToTable("budget_plan");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Budget.BudgetTrackDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<double>("Ammount")
                        .HasColumnType("REAL")
                        .HasColumnName("ammount");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("TEXT")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("date");

                    b.Property<bool>("Paid")
                        .HasColumnType("INTEGER")
                        .HasColumnName("paid");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("payment_date");

                    b.Property<bool>("Repeat")
                        .HasColumnType("INTEGER")
                        .HasColumnName("repeat");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT")
                        .HasColumnName("subject");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_budget_track");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_budget_track_category_id");

                    b.ToTable("budget_track");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Budget.PeriodDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<bool>("Closed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("closed");

                    b.Property<DateTime>("ClosedDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("closed_date");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("date");

                    b.HasKey("Id")
                        .HasName("pk_budget_period");

                    b.ToTable("budget_period");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.FolderDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<Guid?>("FolderId")
                        .HasColumnType("TEXT")
                        .HasColumnName("folder_id");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_folder");

                    b.HasIndex("FolderId")
                        .HasDatabaseName("ix_folder_folder_id");

                    b.ToTable("folder");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.GoalDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<Guid?>("FolderId")
                        .HasColumnType("TEXT")
                        .HasColumnName("folder_id");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_goal");

                    b.HasIndex("FolderId")
                        .HasDatabaseName("ix_goal_folder_id");

                    b.ToTable("goal");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.ProjectDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<Guid>("GoalId")
                        .HasColumnType("TEXT")
                        .HasColumnName("goal_id");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_project");

                    b.HasIndex("GoalId")
                        .HasDatabaseName("ix_project_goal_id");

                    b.ToTable("project");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.TaskDataModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("id");

                    b.Property<int>("Completed")
                        .HasColumnType("INTEGER")
                        .HasColumnName("completed");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<int>("Estimated")
                        .HasColumnType("INTEGER")
                        .HasColumnName("estimated");

                    b.Property<bool>("Everyday")
                        .HasColumnType("INTEGER")
                        .HasColumnName("everyday");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER")
                        .HasColumnName("priority");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("TEXT")
                        .HasColumnName("project_id");

                    b.Property<int>("Rest")
                        .HasColumnType("INTEGER")
                        .HasColumnName("rest");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER")
                        .HasColumnName("state");

                    b.HasKey("Id")
                        .HasName("pk_task");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_task_project_id");

                    b.ToTable("task");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_role_claim");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_role_claim_role_id");

                    b.ToTable("role_claim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT")
                        .HasColumnName("claim_value");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_utilisateur_claim");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_utilisateur_claim_user_id");

                    b.ToTable("utilisateur_claim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT")
                        .HasColumnName("provider_display_name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_utilisateur_login");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_utilisateur_login_user_id");

                    b.ToTable("utilisateur_login");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_utilisateur_role");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_utilisateur_role_role_id");

                    b.ToTable("utilisateur_role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_utilisateur_token");

                    b.ToTable("utilisateur_token");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.HistoryDataModel<Amirez.Infrastructure.Data.Model.Common.TaskDataModel>", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Common.TaskDataModel", "Parent")
                        .WithMany("HistoryVersions")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("fk_history_task_task_data_model_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Amirez.Infrastructure.Data.Model.Common.TaskDataModel", "Version")
                        .WithOne()
                        .HasForeignKey("Amirez.Infrastructure.Data.HistoryDataModel<Amirez.Infrastructure.Data.Model.Common.TaskDataModel>", "VersionId")
                        .HasConstraintName("fk_history_task_version_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");

                    b.Navigation("Version");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Authentication.UtilisateurDataModel", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Authentication.RoleDataModel", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_utilisateur_role_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Budget.BudgetPlanDataModel", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Budget.BudgetCategoryDataModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_budget_plan_budget_category_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Budget.BudgetTrackDataModel", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Budget.BudgetCategoryDataModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_budget_track_budget_category_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.FolderDataModel", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Common.FolderDataModel", "Folder")
                        .WithMany("Folders")
                        .HasForeignKey("FolderId")
                        .HasConstraintName("fk_folder_folder_folder_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.GoalDataModel", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Common.FolderDataModel", "Folder")
                        .WithMany("Goals")
                        .HasForeignKey("FolderId")
                        .HasConstraintName("fk_goal_folder_folder_id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.ProjectDataModel", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Common.GoalDataModel", "Goal")
                        .WithMany("Projects")
                        .HasForeignKey("GoalId")
                        .HasConstraintName("fk_project_goal_goal_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goal");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.TaskDataModel", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Common.ProjectDataModel", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("fk_task_project_project_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Authentication.RoleDataModel", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_role_claim_role_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Authentication.UtilisateurDataModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_utilisateur_claim_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Authentication.UtilisateurDataModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_utilisateur_login_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Authentication.RoleDataModel", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_utilisateur_role_asp_net_roles_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Amirez.Infrastructure.Data.Model.Authentication.UtilisateurDataModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_utilisateur_role_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Authentication.UtilisateurDataModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_utilisateur_token_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.FolderDataModel", b =>
                {
                    b.Navigation("Folders");

                    b.Navigation("Goals");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.GoalDataModel", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.ProjectDataModel", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.TaskDataModel", b =>
                {
                    b.Navigation("HistoryVersions");
                });
#pragma warning restore 612, 618
        }
    }
}
