using Amirez.AmipBackend.Controllers.Generic.Model;
using System;

namespace Amirez.AmipBackend.Controllers.TaskElement.Model
{
    public class TaskUpdateQuery : UpdateBaseQuery
    {
        public string Description { get; set; }

        public int Estimated { get; set; }

        public int Completed { get; set; }

        public int Rest { get; set; }

        public Guid ProjectId { get; set; }
        public int Priority { get; set; }
    }
}
