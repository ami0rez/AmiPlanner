using Amirez.AmipBackend.Controllers.Generic.Model;
using System;

namespace Amirez.AmipBackend.Controllers.TaskElement.Model
{
    public class TaskCreateQuery : CreateBaseQuery
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Estimated { get; set; }

        public int Completed { get; set; }

        public int Rest { get; set; }
        public Guid ProjectId { get; set; }
    }
}
