using Amirez.Infrastructure.Data.Model.Enumerations;
using System;

namespace Amirez.AmipBackend.Controllers.TaskElement.Model
{
    public class TaskFilterQuery
    {
        public bool? Today { get; set; }
        public bool? Everyday { get; set; }
        public Guid? FolderId { get; set; }
        public Guid? GoalId { get; set; }
        public Guid? ProjectId { get; set; }
        public int? Priority { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public TaskStateEnum[] StateList { get; set; }
    }
}
