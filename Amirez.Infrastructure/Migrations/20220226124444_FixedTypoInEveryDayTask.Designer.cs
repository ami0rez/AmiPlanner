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
    [Migration("20220226124444_FixedTypoInEveryDayTask")]
    partial class FixedTypoInEveryDayTask
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

                    b.Property<Guid?>("VersionId")
                        .HasColumnType("TEXT")
                        .HasColumnName("version_id");

                    b.HasKey("Id")
                        .HasName("pk_history");

                    b.HasIndex("VersionId")
                        .HasDatabaseName("ix_history_version_id");

                    b.ToTable("History");
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

            modelBuilder.Entity("Amirez.Infrastructure.Data.HistoryDataModel<Amirez.Infrastructure.Data.Model.Common.TaskDataModel>", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Common.TaskDataModel", "Version")
                        .WithMany("HistoryVersions")
                        .HasForeignKey("VersionId")
                        .HasConstraintName("fk_history_task_version_id");

                    b.Navigation("Version");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.FolderDataModel", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Common.FolderDataModel", "Folder")
                        .WithMany("Folders")
                        .HasForeignKey("FolderId")
                        .HasConstraintName("fk_folder_folder_folder_id");

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("Amirez.Infrastructure.Data.Model.Common.GoalDataModel", b =>
                {
                    b.HasOne("Amirez.Infrastructure.Data.Model.Common.FolderDataModel", "Folder")
                        .WithMany("Goals")
                        .HasForeignKey("FolderId")
                        .HasConstraintName("fk_goal_folder_folder_id");

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
