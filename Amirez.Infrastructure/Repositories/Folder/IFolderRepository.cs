using Amirez.Infrastructure.Data.Model.Common;
using Amirez.Infrastructure.Repositories.Generic;
using System;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.Folder
{
    public interface IFolderRepository : IGenericRepository<FolderDataModel>
    {
        Task<FolderDataModel> FindRoot();
    }
}
