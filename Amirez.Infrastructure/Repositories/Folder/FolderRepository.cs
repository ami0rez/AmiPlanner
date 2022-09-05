using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model.Common;
using Amirez.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.Folder
{
    public class FolderRepository : GenericRepository<FolderDataModel>, IFolderRepository
    {
        public FolderRepository(DatabaseContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Find entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FolderDataModel> FindRoot()
        {
            var root = new FolderDataModel();
            root.Folders = await _context.Set<FolderDataModel>()
                .Include(f => f.Folders)
                .Include(f => f.Goals)
                .AsNoTracking()
               .Where(e => !e.FolderId.HasValue)
               .ToListAsync();
            return root;
        }

        /// <summary>
        /// Find entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<FolderDataModel> FindById(Guid? id)
        {
            return await _context.Set<FolderDataModel>()
                .Include(f => f.Folders)
                .Include(f => f.Goals)
               .AsNoTracking()
               .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
