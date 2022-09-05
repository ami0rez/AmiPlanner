using Amirez.AmipBackend.Controllers.Generic.Model;
using System;

namespace Amirez.AmipBackend.Controllers.Project.Model
{
    public class ProjectListItemResponse : ListItemBaseResponse
    {
        public Guid GoalId { get; set; }
    }
}
