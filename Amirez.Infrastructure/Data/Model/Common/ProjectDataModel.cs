using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amirez.Infrastructure.Data.Model.Common
{
    /// <summary>
    /// Project
    /// </summary>
    [Table("project")]
    public class ProjectDataModel : BaseDataModel
    {
        /// <summary>
        /// Name of project
        /// </summary>
        public string Name { get; set; }

        public Guid GoalId { get; set; }

        public GoalDataModel Goal { get; set; }

        /// <summary>
        /// List of Projects
        /// </summary>
        public List<TaskDataModel> Tasks { get; set; }
    }
}
