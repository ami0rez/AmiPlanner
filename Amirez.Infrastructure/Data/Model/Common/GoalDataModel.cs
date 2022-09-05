using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Data.Model.Common
{
    /// <summary>
    /// Goal
    /// </summary>
    [Table("goal")]
    public class GoalDataModel : BaseDataModel
    {
        /// <summary>
        /// Name of goal
        /// </summary>
        public string Name { get; set; }

        public Guid? FolderId { get; set; }

        public FolderDataModel Folder { get; set; }

        /// <summary>
        /// List of Projects
        /// </summary>
        public List<ProjectDataModel> Projects { get; set; }
    }
}
