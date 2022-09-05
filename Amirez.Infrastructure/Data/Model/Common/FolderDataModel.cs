using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Data.Model.Common
{
    /// <summary>
    /// Folders as Containers
    /// </summary>
    [Table("folder")]
    public class FolderDataModel : BaseDataModel
    {
        /// <summary>
        /// Name of folder
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of Goals
        /// </summary>
        public List<GoalDataModel> Goals { get; set; }

        /// <summary>
        /// Parent Id
        /// </summary>
        public Guid? FolderId { get; set; }
        public FolderDataModel Folder { get; set; }

        /// <summary>
        /// List of Folders
        /// </summary>
        public List<FolderDataModel> Folders { get; set; }
    }
}
