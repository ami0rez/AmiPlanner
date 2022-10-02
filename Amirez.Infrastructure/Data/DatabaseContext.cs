using Amirez.Infrastructure.Data.Model.Authentication;
using Amirez.Infrastructure.Data.Model.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Data
{
    /// <summary>
    /// Database Context
    /// </summary>
    public class DatabaseContext : IdentityDbContext<UtilisateurDataModel, RoleDataModel, Guid,
      IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>,
      IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DbSet<FolderDataModel> Folders { get; set; }
        public DbSet<GoalDataModel> Goals { get; set; }
        public DbSet<ProjectDataModel> Projets { get; set; }
        public DbSet<TaskDataModel> Tasks { get; set; }
        public DbSet<UtilisateurDataModel> Utilisateurs { get; set; }
        public DbSet<HistoryDataModel<TaskDataModel>> TaskHistory { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Customize the ASP.NET Identity model and override the defaults if needed.
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("utilisateur_login");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("utilisateur_claim");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("utilisateur_role");
            modelBuilder.Entity<RoleDataModel>().ToTable("role");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("role_claim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("utilisateur_token");
            modelBuilder.Entity<UtilisateurDataModel>().ToTable("utilisateur");


            modelBuilder.Entity<HistoryDataModel<TaskDataModel>>()
                .HasOne(task => task.Version)
                .WithOne();


            // adding roles to database
            modelBuilder.Entity<RoleDataModel>().HasData(
                Enum.GetValues(typeof(Roles))
                    .Cast<Roles>()
                    .Select(e => new RoleDataModel()
                    {
                        Id = Guid.NewGuid(),
                        RoleType = e,
                        Name = e.ToString()
                    })
            );

            modelBuilder.Entity<FolderDataModel>()
                .HasMany(task => task.Goals)
                .WithOne(h => h.Folder)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FolderDataModel>()
               .HasMany(task => task.Folders)
               .WithOne(h => h.Folder)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GoalDataModel>()
               .HasMany(task => task.Projects)
               .WithOne(h => h.Goal)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectDataModel>()
               .HasMany(task => task.Tasks)
               .WithOne(h => h.Project)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskDataModel>()
                .HasMany(task => task.HistoryVersions)
                .WithOne(h => h.Parent)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
