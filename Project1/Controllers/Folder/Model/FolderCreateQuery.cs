using Amirez.AmipBackend.Controllers.Generic.Model;
using System;

namespace Amirez.AmipBackend.Controllers.Folder.Model
{
    public class FolderCreateQuery: CreateBaseQuery
    {
        public Guid? FolderId { get; set; }
    }
}
