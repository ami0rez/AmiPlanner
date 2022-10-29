using Involys.Common.Utils.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Amirez.AmiPlanner.Utils.Startup
{
    public static class StartupControllersExtensions
    {
        public static IFilterMetadata AddFilters(this MvcOptions options)
        {
            return options.Filters.Add(typeof(HttpGlobalExceptionFilter));
        }
    }
}
