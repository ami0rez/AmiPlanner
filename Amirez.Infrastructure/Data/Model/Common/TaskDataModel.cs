using Amirez.Infrastructure.Data.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amirez.Infrastructure.Data.Model.Common
{
    /// <summary>
    /// Task
    /// </summary>
    [Table("task")]
    public class TaskDataModel : BaseDataModel
    {
        /// <summary>
        /// Name of task
        /// </summary>
        public string Name { get; set; }

        public string Description { get; set; }

        public int Estimated { get; set; }

        public int Completed { get; set; }

        public int Rest { get; set; }

        public Guid ProjectId { get; set; }

        public ProjectDataModel Project { get; set; }

        public TaskStateEnum State { get; set; }

        public DateTime? Date { get; set; }
        public bool Everyday { get; set; }
        public IEnumerable<HistoryDataModel<TaskDataModel>> HistoryVersions { get; set; }
        public int Priority { get; set; }
    }
}
