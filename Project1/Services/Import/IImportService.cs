using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Services.Import
{
    public interface IImportService
    {
        Task SaveImportData(IFormFile file);
    }
}