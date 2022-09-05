using Amirez.AmipBackend.Controllers.Common.Models;
using Amirez.AmipBackend.Controllers.Generic.Model;
using Amirez.Infrastructure.Data.Model.Enumerations;
using System;
using System.Collections.Generic;

namespace Amirez.AmipBackend.Controllers.TaskElement.Model
{
    public class TaskItemResponse : ItemBaseResponse
    {
        public string Description { get; set; }
        public int Estimated { get; set; }
        public int Completed { get; set; }
        public int Rest { get; set; }
        public Guid ProjectId { get; set; }
        public TaskStateEnum State { get; set; }
        public DateTime? Date { get; set; }
        public bool Everyday { get; set; }
        public int Priority { get; set; }
        public IEnumerable<HistoryItemResponse<TaskItemResponse>> HistoryVersions { get; set; }
    }
}
