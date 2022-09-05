using Amirez.AmipBackend.Controllers.Generic.Model;
using System;

namespace Amirez.AmipBackend.Controllers.Project.Model
{
    public class ProjectCreateQuery : CreateBaseQuery
    {
        public Guid GoalId { get; set; }
    }
}
