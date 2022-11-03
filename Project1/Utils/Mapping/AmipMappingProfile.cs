using Amirez.AmipBackend.Controllers.Budget.BudgetPlan.Models;
using Amirez.AmipBackend.Controllers.Budget.BudgetSpent.Models;
using Amirez.AmipBackend.Controllers.Budget.BudgetTrack.Models;
using Amirez.AmipBackend.Controllers.Common.Models;
using Amirez.AmipBackend.Controllers.Folder.Model;
using Amirez.AmipBackend.Controllers.Goal.Model;
using Amirez.AmipBackend.Controllers.Project.Model;
using Amirez.AmipBackend.Controllers.TaskElement.Model;
using Amirez.AmiPlanner.Common.Models;
using Amirez.AmiPlanner.Controllers.Authentication.Account.Models;
using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model.Authentication;
using Amirez.Infrastructure.Data.Model.Budget;
using Amirez.Infrastructure.Data.Model.Common;
using Amirez.Infrastructure.Data.Model.Enumerations;
using AutoMapper;
using System.Linq;

namespace Amirez.AmipBackend.Utils.Mapping
{
    public class AmipMappingProfile : Profile
    {
        public AmipMappingProfile()
        {
            #region Folder Mapping
            CreateMap<FolderDataModel, FolderListItemResponse>();
            CreateMap<FolderDataModel, FolderItemResponse>();
            CreateMap<FolderCreateQuery, FolderDataModel>();
            CreateMap<FolderUpdateQuery, FolderDataModel>();
            CreateMap<FolderDataModel, ListItem>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            #endregion

            #region Goal Mapping
            CreateMap<GoalDataModel, GoalListItemResponse>();
            CreateMap<GoalDataModel, GoalItemResponse>();
            CreateMap<GoalCreateQuery, GoalDataModel>();
            CreateMap<GoalUpdateQuery, GoalDataModel>();
            CreateMap<GoalDataModel, ListItem>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            #endregion

            #region Project Mapping
            CreateMap<ProjectDataModel, ProjectListItemResponse>();
            CreateMap<ProjectDataModel, ProjectItemResponse>();
            CreateMap<ProjectCreateQuery, ProjectDataModel>();
            CreateMap<ProjectUpdateQuery, ProjectDataModel>();
            CreateMap<ProjectDataModel, ListItem>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            #endregion

            #region Task Mapping
            CreateMap<TaskDataModel, TaskListItemResponse>();
            CreateMap<TaskDataModel, TaskFilterListItemResponse>()
                .ForMember(dest => dest.GoalName, opt => opt.MapFrom(src => src.Project.Goal.Name))
                .ForMember(dest => dest.GoalId, opt => opt.MapFrom(src => src.Project.GoalId))
                .ForMember(dest => dest.FolderName, opt => opt.MapFrom(src => src.Project.Goal.Folder.Name));
            CreateMap<TaskDataModel, TaskItemResponse>();
            CreateMap<TaskCreateQuery, TaskDataModel>();
            CreateMap<TaskUpdateQuery, TaskDataModel>();

            CreateMap<HistoryDataModel<TaskDataModel>, HistoryItemResponse<TaskItemResponse>>();
            CreateMap<TaskDataModel, DailyTaskItemResponse>()
                .ForMember(dest => dest.FolderName, opt => opt.MapFrom(src => src.Project.Goal.Folder.Name))
                .ForMember(dest => dest.FolderGoals, opt => opt.MapFrom(src => src.Project.Goal.Folder.Goals != null ? src.Project.Goal.Folder.Goals.Count : 0))
                .ForMember(dest => dest.FolderProjects, opt => opt.MapFrom(src => src.Project.Goal.Folder.Goals != null ? src.Project.Goal.Folder.Goals.SelectMany(g => g.Projects).Count() : 0))
                .ForMember(dest => dest.FolderTasks, opt => opt.MapFrom(src => src.Project.Goal.Folder.Goals != null ? src.Project.Goal.Folder.Goals.SelectMany(g => g.Projects).SelectMany(p => p.Tasks).Count() : 0))
                .ForMember(dest => dest.GoalName, opt => opt.MapFrom(src => src.Project.Goal.Name))
                .ForMember(dest => dest.GoalProjects, opt => opt.MapFrom(src => src.Project.Goal.Projects.Count))
                .ForMember(dest => dest.GoalTasks, opt => opt.MapFrom(src => src.Project.Goal.Projects.SelectMany(p => p.Tasks).Count()))
                .ForMember(dest => dest.NormalTasks, opt => opt.MapFrom(src => src.Project.Tasks.Count(t => !t.Date.HasValue && !t.Everyday)))
                .ForMember(dest => dest.RoutineTasks, opt => opt.MapFrom(src => src.Project.Tasks.Count(t => t.Everyday)))
                .ForMember(dest => dest.TodaysTasks, opt => opt.MapFrom(src => src.Project.Tasks.Count(t => t.Date.HasValue)))
                .ForMember(dest => dest.TodoTasks, opt => opt.MapFrom(src => src.Project.Tasks.Count(t => t.State == TaskStateEnum.Todo)))
                .ForMember(dest => dest.DoingTasks, opt => opt.MapFrom(src => src.Project.Tasks.Count(t => t.State == TaskStateEnum.Doing)))
                .ForMember(dest => dest.AbandonnedTasks, opt => opt.MapFrom(src => src.Project.Tasks.Count(t => t.State == TaskStateEnum.Abandoned)))
                .ForMember(dest => dest.OnHoldTasks, opt => opt.MapFrom(src => src.Project.Tasks.Count(t => t.State == TaskStateEnum.Hold)))
                .ForMember(dest => dest.DoneTasks, opt => opt.MapFrom(src => src.Project.Tasks.Count(t => t.State == TaskStateEnum.Done)));
            #endregion

            #region Authentication
            CreateMap<UtilisateurDataModel, UserProfileResponse>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Admin, opt => opt.MapFrom(src => src.Role.RoleType == Roles.Administrateur));
            #endregion

            #region Budget
            //Budget Category
            CreateMap<BudgetCategoryDataModel, ListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name));

            //Budget Track
            CreateMap<BudgetTrackDataModel, BudgetTrackListItemResponse>();
            CreateMap<BudgetTrackCreateQuery, BudgetTrackDataModel>();
            CreateMap<BudgetTrackUpdateQuery, BudgetTrackDataModel>();
            CreateMap<BudgetPlanDataModel, BudgetTrackDataModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            //Budget Plan
            CreateMap<BudgetPlanDataModel, BudgetPlanListItemResponse>();
            CreateMap<BudgetPlanCreateQuery, BudgetPlanDataModel>();
            CreateMap<BudgetPlanUpdateQuery, BudgetPlanDataModel>();

            //Budget Spent
            CreateMap<BudgetSpentDataModel, BudgetSpentListItemResponse>();
            CreateMap<BudgetSpentCreateQuery, BudgetSpentDataModel>();
            CreateMap<BudgetSpentUpdateQuery, BudgetSpentDataModel>();
            #endregion
        }
    }
}
