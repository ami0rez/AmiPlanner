using Amirez.AmipBackend.Controllers.Generic.Model;
using System;

namespace Amirez.AmipBackend.Controllers.Goal.Model
{
    public class GoalCreateQuery : CreateBaseQuery
    {
        public Guid FolderId { get; set; }
    }
}
