using Amirez.AmiPlanner.Utils.Extensions;
using Amirez.Infrastructure.Repositories.Global;
using Microsoft.AspNetCore.Http;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Services.Import
{
    public class ImportService : IImportService
    {
        protected IGlobalRepository _globalRepository;

        public ImportService(IGlobalRepository globalRepository)
        {
            _globalRepository = globalRepository ?? throw new ArgumentNullException(nameof(globalRepository));
        }

        public virtual async Task SaveImportData(IFormFile file)
        {
            var data = file.ReadExcelToDataTables();
            foreach (var pair in data)
            {
                MethodInfo method = _globalRepository.GetType().GetMethod("CreateRange");
                MethodInfo generic = method.MakeGenericMethod(pair.Key);
                var result = generic.Invoke(_globalRepository, new object[] { pair.Value });
            }

        }
    }
}
