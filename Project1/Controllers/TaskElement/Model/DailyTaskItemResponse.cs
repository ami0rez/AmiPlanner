using Amirez.AmipBackend.Controllers.TaskElement.Model;

namespace Amirez.AmipBackend.Controllers.TaskElement.Model
{
    public class DailyTaskItemResponse: TaskItemResponse
    {
        public string FolderName { get; set; }
        public int FolderGoals { get; set; }
        public int FolderProjects { get; set; }
        public int FolderTasks { get; set; }

        public string GoalName { get; set; }
        public int GoalProjects { get; set; }
        public int GoalTasks { get; set; }
        public string ProjectName { get; set; }
        public int NormalTasks{ get; set; }
        public int RoutineTasks { get; set; }
        public int TodaysTasks { get; set; }
        public int TodoTasks { get; set; }
        public int DoingTasks { get; set; }
        public int AbandonnedTasks { get; set; }
        public int OnHoldTasks { get; set; }
        public int DoneTasks { get; set; }

    }
}
