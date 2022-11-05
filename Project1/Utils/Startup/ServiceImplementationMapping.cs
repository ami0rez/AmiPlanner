using Amirez.AmipBackend.Services.BudgetPlan;
using Amirez.AmipBackend.Services.BudgetSpent;
using Amirez.AmipBackend.Services.BudgetTrack;
using Amirez.AmipBackend.Services.Folder;
using Amirez.AmipBackend.Services.Goal;
using Amirez.AmipBackend.Services.Project;
using Amirez.AmipBackend.Services.TaskElement;
using Amirez.AmiPlanner.Services.Authentication.Accounts;
using Amirez.AmiPlanner.Services.Authentication.Configuration;
using Amirez.AmiPlanner.Services.Authentication.Token;
using Amirez.AmiPlanner.Services.Budget.Period;
using Amirez.AmiPlanner.Services.Import;
using Amirez.AmiPlanner.Services.TaskExpolrer;
using Amirez.Infrastructure.Repositories.Authentication.Token;
using Amirez.Infrastructure.Repositories.Authentication.Utilisateur;
using Amirez.Infrastructure.Repositories.Budget.Period;
using Amirez.Infrastructure.Repositories.BudgetPlan;
using Amirez.Infrastructure.Repositories.BudgetSpent;
using Amirez.Infrastructure.Repositories.BudgetTrack;
using Amirez.Infrastructure.Repositories.Folder;
using Amirez.Infrastructure.Repositories.Global;
using Amirez.Infrastructure.Repositories.Goal;
using Amirez.Infrastructure.Repositories.Project;
using Amirez.Infrastructure.Repositories.TaskElement;
using Microsoft.Extensions.DependencyInjection;

namespace Amirez.AmipBackend.Utils.Startup
{
    public static class ServiceImplementationMapping
    {
        public static void MapServicesToImplementations(this IServiceCollection services)
        {
            //Folder
            services.AddTransient<IFolderRepository, FolderRepository>();
            services.AddTransient<IFolderService, FolderService>();

            //Goal
            services.AddTransient<IGoalRepository, GoalRepository>();
            services.AddTransient<IGoalService, GoalService>();

            //Project
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IProjectService, ProjectService>();

            //Project
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ITaskService, TaskService>();

            //Project
            services.AddTransient<ITaskExplorerService, TaskExplorerService>();

            //Project
            services.AddTransient<IAccountService, AccountService>();

            //Token
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ITokenRepository, TokenRepository>();

            //Configuration
            services.AddTransient<IConfigurationService, ConfigurationService>();
            services.AddTransient<IUtilisateurRepository, UtilisateurRepository>();

            //BudgetTrack
            services.AddTransient<IBudgetTrackService, BudgetTrackService>();
            services.AddTransient<IBudgetTrackRepository, BudgetTrackRepository>();

            //BudgetPlan
            services.AddTransient<IBudgetPlanService, BudgetPlanService>();
            services.AddTransient<IBudgetPlanRepository, BudgetPlanRepository>();

            //Period
            services.AddTransient<IPeriodRepository, PeriodRepository>();
            services.AddTransient<IPeriodService, PeriodService>();

            //Period
            services.AddTransient<IImportService, ImportService>();

            //Period
            services.AddTransient<IGlobalRepository, GlobalRepository>();

            //BudgetSpent
            services.AddTransient<IBudgetSpentService, BudgetSpentService>();
            services.AddTransient<IBudgetSpentRepository, BudgetSpentRepository>();

            //Dashboard
            services.AddTransient<IDashboardService, DashboardService>();
        }
    }
}

