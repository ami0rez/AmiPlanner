using Amirez.AmipBackend.Controllers.Generic.Model;
using Amirez.AmipBackend.Controllers.TaskElement.Model;
using System;
using System.Collections.Generic;

namespace Amirez.AmipBackend.Controllers.Project.Model
{
    public class ProjectItemResponse : ItemBaseResponse
    {
        public Guid GoalId { get; set; }

        public IEnumerable<TaskListItemResponse> Tasks { get; set; }
    }
}
