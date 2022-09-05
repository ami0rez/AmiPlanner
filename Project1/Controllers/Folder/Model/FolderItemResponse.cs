using Amirez.AmipBackend.Controllers.Generic.Model;
using Amirez.AmipBackend.Controllers.Goal.Model;
using System;
using System.Collections.Generic;

namespace Amirez.AmipBackend.Controllers.Folder.Model
{
    public class FolderItemResponse : ItemBaseResponse
    {
        public IEnumerable<GoalListItemResponse> Goals { get; set; }

        /// <summary>
        /// Parent Id
        /// </summary>
        public Guid? FolderId { get; set; }

        /// <summary>
        /// List of Folders
        /// </summary>
        public List<FolderListItemResponse> Folders { get; set; }
    }
}
