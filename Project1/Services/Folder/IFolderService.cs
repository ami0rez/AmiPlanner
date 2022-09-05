using Amirez.AmipBackend.Controllers.Folder.Model;
using Amirez.AmipBackend.Services.Generic;
using System;
using System.Threading.Tasks;

namespace Amirez.AmipBackend.Services.Folder
{
    public interface IFolderService : IGenericService<
        FolderListItemResponse,
        FolderItemResponse,
        FolderCreateQuery,
        FolderUpdateQuery>
    {

        Task<FolderItemResponse> FindByParentId(Guid? parentId);
    }
}
