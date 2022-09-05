using Amirez.AmipBackend.Controllers.Generic.Model;
using Amirez.AmipBackend.Controllers.Project.Model;
using System;
using System.Collections.Generic;

namespace Amirez.AmipBackend.Controllers.Goal.Model
{
    public class GoalItemResponse : ItemBaseResponse
    {
        public Guid FolderId { get; set; }
        public IEnumerable<ProjectListItemResponse> Projects { get; set; }
    }
}
