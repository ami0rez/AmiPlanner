using Amirez.AmiPlanner.Common.Models;
using System.Collections.Generic;

namespace Amirez.AmiPlanner.Controllers.TaskExpolrer.Model
{
    public class TaskFilterOptions
    {
        public List<ListItem> Folders { get; set; }
        public List<ListItem> Goals { get; set; }
        public List<ListItem> Projects { get; set; }
    }
}
