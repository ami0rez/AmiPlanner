using Amirez.AmipBackend.Services.Folder;
using Amirez.AmipBackend.Services.Goal;
using Amirez.AmipBackend.Services.Project;
using Amirez.AmipBackend.Services.TaskElement;
using Amirez.AmiPlanner.Services.TaskExpolrer;
using Amirez.Infrastructure.Repositories.Folder;
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
        }
    }
}
