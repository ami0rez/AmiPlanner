using Amirez.AmipBackend.Controllers.Generic.Model;
using Amirez.Infrastructure.Data.Model.Enumerations;
using System;

namespace Amirez.AmipBackend.Controllers.TaskElement.Model
{
    public class TaskListItemResponse : ListItemBaseResponse
    {
        public Guid ProjectId { get; set; }
        public Guid GoalId { get; set; }
        public TaskStateEnum State { get; set; }
        public DateTime? Date { get; set; }
        public bool Everyday { get; set; }
        public int Priority { get; set; }
    }
}
